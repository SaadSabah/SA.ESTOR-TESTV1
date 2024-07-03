using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SA.ESTOR_TESTV1.Models;
using SA.ESTOR_TESTV1.Services;
using System.Net.Http.Headers;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SA.ESTOR_TESTV1.Controllers
{
    public class HandMProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment environment;

        public HandMProductsController(ApplicationDbContext context, IWebHostEnvironment _environment)
        {
            this._context = context;
            this.environment = _environment;
        }

        public IActionResult Index()
        {
            var hproducts = _context.HandMProducts.OrderByDescending(p => p.Id).ToList(); // show the handmade products to the admin
            return View(hproducts);
        }

        public IActionResult HMProducts()
        {
            var hm_products = _context.HandMProducts.OrderByDescending((x) => x.Id).ToList();
            return View("HMProducts", hm_products);

        }
		/*************/

		







		/*************/




		[Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(NewHMProduct newhmproduct)
        {
            if (newhmproduct.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "The file image is required");
            }

            if (!ModelState.IsValid)
            {
                return View(newhmproduct);
            }

            //Save the image file
            string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            newFileName += Path.GetExtension(newhmproduct.ImageFile!.FileName);

            string imageFullPath = environment.WebRootPath + "/HandMade-IMGs/" + newFileName;
            using (var stream = System.IO.File.Create(imageFullPath))
            {
                newhmproduct.ImageFile.CopyTo(stream);
            }

            //save the new product in the database
            HandMProduct _product = new HandMProduct()
            {
                Name = newhmproduct.Name,
                Brand = newhmproduct.Brand,
                Category = newhmproduct.Category,
                Price = newhmproduct.Price,
                Description = newhmproduct.Description,
                ImageFileName = newFileName,
                CreatedAt = DateTime.Now,
                Email = newhmproduct.Email,
                PhoneNumber = newhmproduct.PhoneNumber,
            };

            _context.HandMProducts.Add(_product);
            _context.SaveChanges();

            return RedirectToAction("Index", "HandMProducts");
        }

        [Authorize(Roles = "Adminplus")]
        public IActionResult Edit(int id)
        {
            var product = _context.HandMProducts.Find(id);

            if (product == null)
            {
                return RedirectToAction("Index", "HandMProducts");
            }

            //create newproduct from product
            var newproduct = new NewHMProduct()
            {
                Name = product.Name,
                Brand = product.Brand,
                Category = product.Category,
                Price = product.Price,
                Description = product.Description,
                Email = product.Email,
                PhoneNumber = product.PhoneNumber,



            };

            ViewData["HandMProductId"] = product.Id;
            ViewData["ImageFileName"] = product.ImageFileName;
            ViewData["CreatedAt"] = product.CreatedAt.ToString("MM/dd/yyyy");

            return View(newproduct);
        }



        [HttpPost]
        public IActionResult Edit(int id, NewHMProduct newproduct)
        {
            var product = _context.HandMProducts.Find(id);

            if (product == null)
            {
                return RedirectToAction("Index", "HandMProducts");
            }

            if (!ModelState.IsValid)
            {
                ViewData["HandMProductId"] = product.Id;
                ViewData["ImageFileName"] = product.ImageFileName;
                ViewData["CreatedAt"] = product.CreatedAt.ToString("MM/dd/yyyy");
                return View(newproduct);
            }

            //update the image file if we have a new image file
            string newFileName = product.ImageFileName;
            if (newproduct.ImageFile != null)
            {
                newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                newFileName += Path.GetExtension(newproduct.ImageFile.FileName);

                string imageFullPath = environment.WebRootPath + "/HandMade-IMGs/" + newFileName;
                using (var stream = System.IO.File.Create(imageFullPath))
                {
                    newproduct.ImageFile.CopyTo(stream);
                }

                //delete the old image
                string oldImageFullPath = environment.WebRootPath + "/HandMade-IMGs/" + product.ImageFileName;
                System.IO.File.Delete(oldImageFullPath);
            }

            //update the product in the database
            product.Name = newproduct.Name;
            product.Brand = newproduct.Brand;
            product.Category = newproduct.Category;
            product.Price = newproduct.Price;
            product.Description = newproduct.Description;
            product.ImageFileName = newFileName;
            product.Email = newproduct.Email;
            product.PhoneNumber = newproduct.PhoneNumber;


            _context.SaveChanges();
            return RedirectToAction("Index", "HandMProducts");
        }


        [Authorize(Roles = "Adminplus")]
        public IActionResult Delete(int id) //delete product
        {
            var product = _context.HandMProducts.Find(id);

            if (product == null)
            {
                return RedirectToAction("Index", "HandMProducts");
            }

            string imageFullPath = environment.WebRootPath + "/HandMade-IMGs/" + product.ImageFileName;
            System.IO.File.Delete(imageFullPath);

            _context.HandMProducts.Remove(product);
            _context.SaveChanges();

            return RedirectToAction("Index", "HandMProducts");
        }
    }

}
