using Microsoft.AspNetCore.Mvc;
using BooksStore.Models;
using System.Linq;
using BooksStore.Models.ViewModels;

namespace BooksStore.Controllers
{
    public class HomeController : Controller
    {

        private IBooksStoreRepository repository;
        public int PageSize = 3;
        public HomeController(IBooksStoreRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index(string genre, int bookPage = 1)
=> View(new BooksListViewModel
{
    Books = repository.Books
.Where(p => genre == null || p.Genre == genre)

.OrderBy(p => p.BookID)
.Skip((bookPage - 1) * PageSize)
.Take(PageSize),
    PagingInfo = new PagingInfo
    {
        CurrentPage = bookPage,
        ItemsPerPage = PageSize,
        TotalItems = genre == null ?
repository.Books.Count() :
repository.Books.Where(e =>
e.Genre == genre).Count()
    },
    CurrentGenre = genre
});


    }


}