using System.Text.Json;
using WeatherApp.Models;

public class WeatherService {
    private readonly string _apiKey;
    private readonly HttpClient _httpClient;

    public WeatherService(IConfiguration configuration) {
        _apiKey = configuration.GetValue<string>("OpenWeatherMap:ApiKey");
        _httpClient = new HttpClient();
    }

    public async Task<WeatherInfo> GetWeatherAsync(string city) {
        string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}&units=metric";
        var response = await _httpClient.GetStringAsync(url);
        var weatherInfo = JsonSerializer.Deserialize<WeatherInfo>(response);
        return weatherInfo;
    }
}