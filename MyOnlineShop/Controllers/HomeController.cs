using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyOnlineShop.Models.ViewModels.UI;
using MyOnlineShop.Models;
using MyOnlineShop.Data;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyOnlineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly DataContext _context;
        public class BookDTO
        {
            public string Title { get; set; }
            public string Picture { get; set; }
        }

        public HomeController(DataContext context)
        {
            _context = context;
        }

        // Model for API result
        /*        public class WebApiResult
                {
                    public int State { get; set; } = 200;
                    public object Data { get; set; }
                    public string Message { get; set; } = "Success";

                    public WebApiResult(object data)
                    {
                        Data = data;
                    }
                }*/

        // The example of customize ApiResult
        [Authorize]
        [Route("index")]
        [HttpGet]
        public WebApiResult Get()
        {
            BookDTO book = new BookDTO() { Title = "My 1st Book", Picture = "/pic/1.png" };

            BookDTO book1 = new BookDTO() { Title = "My 2nd Book", Picture = "/pic/2.png" };


            WebApiResult result = new WebApiResult(new List<BookDTO>() { book, book1 });
            return result;
        }

        [Authorize(Roles = UserRoles.Admin)]
        [Route("admin")]
        [HttpGet]
        public WebApiResult admin()
        {
            string UserName = HttpContext.User.Identity.Name;
            WebApiResult result = new WebApiResult(new {words = $"welcome to admin panel. My username is {UserName}" });
            return result;
        }

        [Route("shop/{id}")]
        [HttpGet]
        public WebApiResult Shop(int id)
        {
            
            List<Book> books = _context.Books.Where(m=>m.CategoryId == id).ToList();

            if(books.Count == 0)
                return new WebApiResult() { Status = 404, Message = "Book not found." };

            var bookList = books.Select<Book, BookDTO>(x => new BookDTO() { Title = x.Title, Picture = x.Picture });
            return new WebApiResult(bookList);
            


        }

    }
}
