using System.Data;
using System.Web;
using BulkyWeb.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BulkyWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string? Name { get; set; }

        [DisplayName("Displayb Order")]
        [Range(1,100)]
        public int DisplayOrder { get; set; }
    }
}
