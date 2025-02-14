using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;

namespace C_Scherp_Api.Models
{
    public class Ingredient
    {

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")] 
        public decimal Energy { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Fat { get; set; }

        [Required]
        [Column("saturated_fat", TypeName = "decimal(18, 2)")]
        public decimal SaturatedFat { get; set; }

        [Required]
        [Column("unsaturated_fat", TypeName = "decimal(18, 2)")]
        public decimal UnsaturatedFat { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Carbohydrates { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Sugars { get; set; }

        [Required]
        [Column("dietary_fiber", TypeName = "decimal(18, 2)")]
        public decimal DietaryFiber { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Protein { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Salt { get; set; }

    }
}
