using Microsoft.AspNetCore.Mvc;

namespace MeroTender.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}