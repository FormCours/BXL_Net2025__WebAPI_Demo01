using Demo_WebAPI_01.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo_WebAPI_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // Remarque, L'utilisation du service sera amélioré mercredi :p
        private ProductService _productService = new ProductService();

        // TODO Faire la méthode pour envoyer la liste des produits

        // TODO Faire la méthode pour envoyer  un produit via son id
    }
}
