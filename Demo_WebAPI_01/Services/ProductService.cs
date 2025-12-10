using Demo_WebAPI_01.Models;

namespace Demo_WebAPI_01.Services
{
    public class ProductService
    {
        private static List<Product> _products = new List<Product>
        {
            new Product() { Id = 1, Name = "Stylo bille", Description = "Stylo bleu à encre fluide", Price = 1.50, InStock = true },
            new Product() { Id = 2, Name = "Cahier A4", Description = "Cahier 100 pages lignées", Price = 2.99, InStock = true },
            new Product() { Id = 3, Name = "Clé USB 32GB", Description = null, Price = 12.90, InStock = true },
            new Product() { Id = 4, Name = "Sac à dos", Description = "Sac à dos noir pour ordinateur portable", Price = 39.99, InStock = true },
            new Product() { Id = 5, Name = "Bouteille d’eau", Description = "Bouteille réutilisable 750ml", Price = 9.50, InStock = false },
            new Product() { Id = 6, Name = "Casque audio", Description = "Casque sans fil Bluetooth", Price = 59.00, InStock = true },
            new Product() { Id = 7, Name = "Lampe de bureau", Description = "Lampe LED réglable", Price = 24.99, InStock = true },
            new Product() { Id = 8, Name = "Souris sans fil", Description = "Souris ergonomique USB", Price = 19.99, InStock = true },
            new Product() { Id = 9, Name = "Clavier mécanique", Description = "Clavier rétroéclairé pour gaming", Price = 79.00, InStock = false },
            new Product() { Id = 10, Name = "Tasse en céramique", Description = "Tasse blanche 300ml", Price = 4.50, InStock = true }
        };

        public IEnumerable<Product> GetAll()
        {
            return _products.AsReadOnly();
        }

        public Product? GetById(int id)
        {
            //Product? result = null;
            //foreach(Product p  in _products)
            //{
            //    if(p.Id == id)
            //    {
            //        if (result is not null) throw new Exception();

            //        result = p;
            //    }
            //}
            //return result;

            return _products.SingleOrDefault(p => p.Id == id);
        }

        public Product Insert(Product data) {

            // Obtenir le prochain "id"
            int nextId = _products.Max(p => p.Id) + 1;

            // Simulation de l'objet généré en "db"
            Product productToAdd = new Product()
            {
                Id = nextId,
                Name = data.Name,
                Description = data.Description?.Trim(),
                Price = data.Price,
                InStock = data.InStock
            };

            // Ajout de l'élément dans la liste
            _products.Add(productToAdd);

            // Retour du produit qui a été ajouté
            return productToAdd;
        }
    }
}
