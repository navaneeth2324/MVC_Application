using Microsoft.AspNetCore.Mvc;
using MVC_Application.Models;

namespace MVC_Application.Controllers
{
    public class ItemsController : Controller
    {
        public IActionResult Overview()
        {
            var item = new Item() { Name = "Recliner" };
            return View(item);
        }

        public IActionResult Edit(int id)
        {
            return Content("Editing item with id " + id);
        }
    }
}
