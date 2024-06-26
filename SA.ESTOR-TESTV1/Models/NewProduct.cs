using System.ComponentModel.DataAnnotations;

namespace SA.ESTOR_TESTV1.Models
{
	public class NewProduct
	{
		[Required(ErrorMessage = "Enter a Product Name"), MaxLength(100)]
		public string Name { get; set; } = "";
		[Required(ErrorMessage = "Enter a Product Brand"), MaxLength(100)]
		public string Brand { get; set; } = "";
		[MaxLength(100), Required(ErrorMessage = "Enter a Category")]
		public string Category { get; set; } = "";
		[Required(ErrorMessage = "Enter a Price")]
		public decimal Price { get; set; }
		[Required(ErrorMessage = "Enter a Product Description")]
		public string Description { get; set; } = "";
		[Display(Name = "Image File")]
		public IFormFile? ImageFile { get; set; }
		public string Email { get; set; } = "";
		
		
	}
}
