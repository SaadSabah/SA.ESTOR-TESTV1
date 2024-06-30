using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SA.ESTOR_TESTV1.Models;
using SA.ESTOR_TESTV1.Services;

namespace SA.ESTOR_TESTV1.Controllers
{
	public class ProductsController : Controller
	{
		private readonly ApplicationDbContext context;
		private readonly IWebHostEnvironment environment;

		public ProductsController(ApplicationDbContext context, IWebHostEnvironment environment)
		{
			this.context = context;
			this.environment = environment;
		}

		public IActionResult Index()
		{
			var products = context.Products.OrderByDescending(p => p.Id).ToList(); // show the new item first
			return View(products);
		}

		public IActionResult ShowProducts()
		{
			var myModel = context.Products.OrderByDescending((p) => p.Id).ToList();
			return View("Index", myModel);

		}

		public IActionResult HomeIndex()
		{
			var myProduct = context.Products.OrderByDescending(x => x.Id).ToList();
			return View("HomeIndex", myProduct);
		}

		[Authorize]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(NewProduct newproduct)
		{
			if (newproduct.ImageFile == null)
			{
				ModelState.AddModelError("ImageFile", "The file image is required");
			}

			if (!ModelState.IsValid)
			{
				return View(newproduct);
			}

			//Save the image file
			string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
			newFileName += Path.GetExtension(newproduct.ImageFile!.FileName);

			string imageFullPath = environment.WebRootPath + "/Products-Images/" + newFileName;
			using (var stream = System.IO.File.Create(imageFullPath))
			{
				newproduct.ImageFile.CopyTo(stream);
			}

			//save the new product in the database
			Product product = new Product()
			{
				Name = newproduct.Name,
				Brand = newproduct.Brand,
				Category = newproduct.Category,
				Price = newproduct.Price,
				Description = newproduct.Description,
				ImageFileName = newFileName,
				CreatedAt = DateTime.Now,
				Email = newproduct.Email,
				
			};

			context.Products.Add(product);
			context.SaveChanges();

			return RedirectToAction("Index", "Products");
		}

		[Authorize(Roles = "Adminplus")]
		public IActionResult Edit(int id)
		{
			var product = context.Products.Find(id);

			if (product == null)
			{
				return RedirectToAction("Index", "Products");
			}

			//create newproduct from product
			var newproduct = new NewProduct()
			{
				Name = product.Name,
				Brand = product.Brand,
				Category = product.Category,
				Price = product.Price,
				Description = product.Description,
				Email = product.Email,
				
			};

			ViewData["ProductId"] = product.Id;
			ViewData["ImageFileName"] = product.ImageFileName;
			ViewData["CreatedAt"] = product.CreatedAt.ToString("MM/dd/yyyy");

			return View(newproduct);
		}

		
		[HttpPost]
		public IActionResult Edit(int id, NewProduct newproduct)
		{
			var product = context.Products.Find(id);

			if (product == null)
			{
				return RedirectToAction("Index", "Products");
			}

			if (!ModelState.IsValid)
			{
				ViewData["ProductId"] = product.Id;
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

				string imageFullPath = environment.WebRootPath + "/Products-Images/" + newFileName;
				using (var stream = System.IO.File.Create(imageFullPath))
				{
					newproduct.ImageFile.CopyTo(stream);
				}

				//delete the old image
				string oldImageFullPath = environment.WebRootPath + "/Products-Images/" + product.ImageFileName;
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
			

			context.SaveChanges();
			return RedirectToAction("Index", "Products");
		}


		[Authorize(Roles = "Adminplus")]
		public IActionResult Delete(int id) //delete product
		{
			var product = context.Products.Find(id);

			if (product == null)
			{
				return RedirectToAction("Index", "Products");
			}

			string imageFullPath = environment.WebRootPath + "/Products-Images/" + product.ImageFileName;
			System.IO.File.Delete(imageFullPath);

			context.Products.Remove(product);
			context.SaveChanges();

			return RedirectToAction("Index", "Products");
		}
	}
}
