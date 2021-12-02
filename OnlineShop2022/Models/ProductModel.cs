using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop2022.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Description { get; set; }

        [Required]
        [Range(0.0, 999999.99)]
        public double Price { get; set; }

        public string ImagePath { get; set; }
    }
}
