using System.ComponentModel.DataAnnotations;

namespace Fashioninventorysystem.Models
{
    public class Product
    {
        [Key]
        public int Product_id { get; set; }

        [Required]
        [StringLength(100)]
        public string Product_name { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string Product_description { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Product_category { get; set; } = string.Empty;

        [Required]
        public int Product_quantity { get; set; }

        [Required]
        [StringLength(50)]
        public string Size { get; set; } = string.Empty;

        [Required]
        [Range(0, 999999.99)]
        public decimal Price { get; set; }

        [StringLength(200)]
        public string Brand { get; set; } = string.Empty;

        [StringLength(200)]
        public string Color { get; set; } = string.Empty;


        public DateTime DateAdded { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
