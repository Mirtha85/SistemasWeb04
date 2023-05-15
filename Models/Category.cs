using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SistemasWeb01.Models
{
    public class Category
    {
        // [BindNever]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please enter the category name")]
        [Display(Name = "Category name")]
        [StringLength(50)]
        public string CategoryName { get; set; } = string.Empty;


        
        [Display(Name = "Description")]
        public string? Description { get; set; }


        public List<Pie>? Pies { get; set; }
        
    }
}