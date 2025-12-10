using Demo_WebAPI_01.Dto;
using Demo_WebAPI_01.Models;
using Demo_WebAPI_01.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo_WebAPI_01.Controllers
{
    // Role du controller :
    //  - Exposer les routes (endpoints) via des méthodes

    // Role des méthodes du controller : 
    //  - Interpréter les données de la requete (route, parametre, body, ...)
    //  - Réaliser le traitement par l'intermedaire du service
    //  - Envoyer la réponse adapté (Status de la requete & les données au format DTO)

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // Remarque, L'utilisation du service sera amélioré mercredi :p
        private ProductService _productService = new ProductService();

        // (GET) /api/product
        // Faire la méthode pour envoyer la liste des produits
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            IEnumerable<Product> products = _productService.GetAll();

            return Ok(products.Select(p => new ProductItemResponseDto()
            {
                Id = p.Id,
                Name = p.Name,
            }));
        }

        // (GET) /api/product/{id}
        // Faire la méthode pour envoyer un produit via son id
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            Product? product = _productService.GetById(id);
            if (product is null) 
            {
                return NotFound("Erreur : pas de produit trouvé");
            }
            
            return Ok(new ProductDetailResponseDto()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description ?? "N/A",
                Price = product.Price,
                InStock = product.InStock
            });
        }

    }
}
