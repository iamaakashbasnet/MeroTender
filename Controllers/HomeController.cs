using Microsoft.AspNetCore.Mvc;

namespace MeroTender.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        if (User.Identity is { IsAuthenticated: true })
        {
            return RedirectToAction("Dashboard", "Account");
        }

        return View();
    }
}