namespace Demo_WebAPI_01.Models
{
    public class Product
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string? Description { get; set; }
        public required double Price { get; set; }
        public required bool InStock { get; set; }
    }
}
