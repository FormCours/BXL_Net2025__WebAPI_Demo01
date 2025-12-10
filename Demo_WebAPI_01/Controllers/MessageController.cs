using Demo_WebAPI_01.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo_WebAPI_01.Controllers
{
    [Route("api/[controller]")]  // → Il utilise "Message" comme nom de route, car c'est le nom du Controller
    [ApiController]
    public class MessageController : ControllerBase
    {
        // (GET) /api/message
        [HttpGet]   
        public IActionResult MessageOfDay()
        {
            // Traitement...
            string msg = $"Bonjour, nous sommes le {DateTime.Today.ToShortDateString()}";

            // Réponse du endpoint
            // - Renvoyer le status http adapté (Ok - 200)
            // - Donnée formatée avec le Dto désiré
            return Ok(new MessageResponseDto()
            {
                Message = msg
            });
        }

        // (GET) /api/message/hello
        [HttpGet("hello")]   
        public IActionResult SayHello()
        {
            return Ok(new MessageResponseDto()
            {
                Message = "Hello World"
            });
        }

        // (GET) /api/message/salutation/robert
        [HttpGet("salutation/{name}")]
        public IActionResult SaySalutation(string name)
        {
            if(name.ToLower() == "gripsou")
            {
                return BadRequest();
            }

            return Ok(new MessageResponseDto()
            {
                Message = $"Bonjour {name} ! On fait la pause ?"
            });
        }
    }
}
