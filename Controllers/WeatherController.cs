using Microsoft.AspNetCore.Mvc;

public class WeatherController : Controller {
    private readonly WeatherService _weatherService;

    public WeatherController(WeatherService weatherService) {
        _weatherService = weatherService;
    }

    [HttpGet]
    public IActionResult Index() {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> GetWeather(string city) {
        
        try {
            await _weatherService.GetWeatherAsync(city);
        }
        catch (Exception) {
            return View("WeatherDetails", null);
        }
        return View("WeatherDetails", await _weatherService.GetWeatherAsync(city));
    }
}