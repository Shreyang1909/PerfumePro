using System;
using System.ComponentModel.DataAnnotations;

namespace PerfumePro.Models
{
    public class Perfume
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        public string Brand { get; set; }

        public string Fragrance { get; set; }

        public string Gender { get; set; }

        public string Country { get; set; }
        public decimal Price { get; set; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5 ")]
        public double Rating { get; set; }
    }
}