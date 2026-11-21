using Demo01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo01.Controllers
{
    //[Route("Test")]
    public class ProductController : Controller
    {

        [HttpGet]
        public IActionResult GetById([FromQuery]int Id , [FromQuery(Name = "id2")] int OtherId)
        {
            return View();
        }









        // GET -> BaseUrl/Product/Search => id=0
        // GET -> BaseUrl/Product/Search/10 => id=0
        // GET -> BaseUrl/Product/Search?id=20 => id=20 [Bind from Query]
        // GET -> BaseUrl/Product/Search/10?id=20 => id=10 in order will take it from route
        // I can Choose the Source of the value by using [FromQuery] or [FromRoute] or [FromHeader] or [FromForm] or [FromBody]
        //[HttpGet]
        //public IActionResult Search([FromQuery]int id )
        //{
        //    return View();
        //}// Simple Parameter

        // GET -> BaseUrl/Product/Search?term=phone&minPrice=100&page=1
        // GET -> BaseUrl/Product/Search?term=phone&page=1
        // GET -> BaseUrl/Product/Search?minPrice=100&page=1
        // GET -> BaseUrl/Product/Search?page=1
        // GET -> BaseUrl/Product/Search // Default Values 
        // Rapping inside Obj
        //[HttpGet]
        //public IActionResult Search(string? term , decimal? minPrice , int page)
        //{
        //    return View();
        //}// Simple Parameter

        [HttpGet]
        public IActionResult Search(ProductFilter productFilter)
        {
            return View();
        }// Complex Parameter 




        // Discard Convention Routing
        // Routing : GET -> BaseUrl/Product/JsonAction
        [HttpGet("json")]
        public IActionResult JsonAction()
        {
            return Json("Hello From Json Action");
        }
        // Not Accept cause it called Id
        // GET -> BaseUrl/Product/GetProductByCode/code=1 
        [HttpGet("ProductCode/{code:int}")]
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
