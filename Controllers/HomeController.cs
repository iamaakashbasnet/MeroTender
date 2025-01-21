using Microsoft.AspNetCore.Mvc;

namespace MeroTender.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        if (User.Identity != null && User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Dashboard", "Account");
        }

        return View();
    }
}