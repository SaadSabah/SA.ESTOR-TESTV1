using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SA.ESTOR_TESTV1.Models
{
    public class HandMProduct
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter a Product Name"), MaxLength(100)]
        public string Name { get; set; } = "";
        [Required(ErrorMessage = "Enter a Product Brand"), MaxLength(100)]
        public string Brand { get; set; } = "";
        [MaxLength(100)]
        public string Category { get; set; } = "";
        [Precision(16, 2)]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Enter a Product Description")]
        public string Description { get; set; } = "";
        [Display(Name = "Image File Name"), MaxLength(100)]
        public string ImageFileName { get; set; } = "";
        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }
        [Required(ErrorMessage = "Enter an email address"), MaxLength(100)]
        public string Email { get; set; } = "";
       [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; } = "";

    }
}
