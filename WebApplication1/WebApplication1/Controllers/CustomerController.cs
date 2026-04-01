using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CustomerController : Controller
    {
        public static List<Customer> customers = new List<Customer>
        {
            new Customer { Id = 1, Name = "Alice", Amount = 250.0 },
            new Customer { Id = 2, Name = "Bob", Amount = 150.5 },
            new Customer { Id = 3, Name = "Charlie", Amount = 300.75 }
        };
        public IActionResult Index()
        {
            ViewBag.Message = "Customer Management Page";
            ViewBag.CustomerCount = customers.Count();
            ViewBag.CustomerList = customers;
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }
        [Route("~/")]
        [Route("/sample/message")]
        public IActionResult Message()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Customer customer)
        {
            return View("Authenticated", customer);
        }
    }
}
