using System.ComponentModel.DataAnnotations;

namespace Demo_WebAPI_01.Dto
{
    // ResponseDto : Formattage des données envoyé par la WebAPI
    public class ProductItemResponseDto
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
    }

    public class ProductDetailResponseDto
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required double Price { get; set; }
        public required bool InStock { get; set; }
    }

    // RequestDto : Format et la validation des données reçus par la WebAPI
    public class ProductRequestDto
    {
        [Required(ErrorMessage = "Mon gars, il faut un nom au produit !")]
        [MinLength(3, ErrorMessage = "Le nom du produit doit faire 3 caracteres !")]
        [MaxLength(50, ErrorMessage = "Abuse pas ! C'est maximum 50 caracteres !")]
        public required string Name { get; set; }

        [MaxLength(4_000)]
        public required string? Description { get; set; }

        [Required]
        [Range(0, 1_000_000)]
        public required double Price { get; set; }
    }
}
