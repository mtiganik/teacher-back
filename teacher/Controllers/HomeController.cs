using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace teacher.Controllers
{
    [Route("/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new[] { "hello", "World" };
        }
    }
}
