using System.ComponentModel.DataAnnotations;

namespace Layout.ViewModels
{
    public class ProductViewModel
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage ="Name field cannot be empty")]
        public string? Name { get; set; }
        [Required(ErrorMessage ="Price field cannot be empty")]
        public decimal? Price { get; set; }
        [Required(ErrorMessage = "Stock field cannot be empty")]
        public int? Stock { get; set; }

        [Required(ErrorMessage = "Color should be selected")]
        public string? Color { get; set; }
        [Required(ErrorMessage = "Date should be selected")]
        public DateTime? PublishDate { get; set; }

        [Required(ErrorMessage = "Description cannot be empty")]
        public string Description { get; set; }
        public bool IsPublish { get; set; }
        [Required(ErrorMessage = "Expire should be selected")]
        public string? Expire { get; set; }
    }
}
