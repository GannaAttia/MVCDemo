using Microsoft.AspNetCore.Mvc;

namespace Demo01.Controllers
{
    public class ProductController : Controller
    {
        // Action 
        // Attributes: [HttpGet], [HttpPost], [HttpPut], [HttpDelete], [HttpPatch], [HttpHead], [HttpOptions]
        [HttpGet] // By Default 
        // Routing : GET -> BaseUrl/Product/TestAction
        public string TestAction() 
        {
            return "Hello";
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
