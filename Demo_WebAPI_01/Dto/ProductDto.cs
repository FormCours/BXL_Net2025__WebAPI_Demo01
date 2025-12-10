namespace Demo_WebAPI_01.Dto
{
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
}
