using Demo01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo01.Controllers
{
    [Route("Test")]
    public class ProductController : Controller
    {
        // Discard Convention Routing
        // Routing : GET -> BaseUrl/Product/JsonAction
        [HttpGet("json")]
        public IActionResult JsonAction()
        {
            return Json("Hello From Json Action");
        }
        // Not Accept cause it called Id
        // GET -> BaseUrl/Product/GetProductByCode/code=1 
        [HttpGet("ProductCode/{code}")]
        public IActionResult GetProductByCode(int code)
        {
            return Json(new Product() { Id= code , Name="Phone"});
        }

        #region Action
        // Attributes: [HttpGet], [HttpPost], [HttpPut], [HttpDelete], [HttpPatch], [HttpHead], [HttpOptions]
        //[HttpGet] // By Default 
        // Routing : GET -> BaseUrl/Product/TestAction
        //public string TestAction()
        //{
        //    return "Hello";
        //}
        #endregion

        #region Action Results
        public ContentResult Test()
        {
            //ContentResult result = new ContentResult()
            //{
            //    Content = "<h1>Hello</h1>",
            //    StatusCode = 200,
            //    ContentType = "text/html"
            //};

            // Use Heler Method Instead of creating a new instance of ContentResult
            return Content("<h1>Hello</h1>", "text/html");
        }
        public ViewResult Index()
        {
            // Throw an Exception because he cannot find 
            // the view file in the Views/Product folder with the name Index.cshtml
            return View();
        }

        [HttpGet]
        public JsonResult GetProducts()
        {
            var products = new List<Product>()
            {
                new Product() { Id = 1, Name = "Product 1" },
                new Product() { Id = 2, Name = "Product 2" },
                new Product() { Id = 3, Name = "Product 3" }
            };
            return Json(products);
        }

        // Return Parent Instead of Child 
        public IActionResult GetProductById(int id)
        {
            if (id < 0)
                return BadRequest();
            else if (id == 0)
                return RedirectToAction(nameof(Index));
            else if (id < 10)
                return NotFound();
            else
                return Json(new { Id = id, Name = "Laptop" });
        }
        // Every helper return a response with its status code 
        [HttpGet]
        public IActionResult RedirectToLink()
        {
            return Redirect("https://www.google.com/search?q=goog&oq=goog&gs_lcrp=EgZjaHJvbWUyBggAEEUYOTITCAEQLhiDARjHARixAxjRAxiABDIGCAIQIxgnMgYIAxBFGEEyBggEEEUYPDIGCAUQRRg8MgYIBhBFGEEyBggHEEUYQdIBCDI4NTZqMGo3qAIIsAIB&sourceid=chrome&source=chrome.ob&ie=UTF-8");

        }

        public IActionResult FileAction()
        {
            var fileBytes = System.IO.File.ReadAllBytes("wwwroot/files/The Stryker Cyberattack.pdf");
            return File(fileBytes, "application/pdf", "The Stryker Cyberattack.pdf");
        }









        #endregion

    }
}
