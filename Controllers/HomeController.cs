using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models;

public class HomeController : Controller {
    public IActionResult Index() {
        return View();
    }
    
    public IActionResult Privacy()
    {
        return View();
    }
}