using System.ComponentModel.DataAnnotations;

namespace Books_Shop.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public DateTime DateOfCreate { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
