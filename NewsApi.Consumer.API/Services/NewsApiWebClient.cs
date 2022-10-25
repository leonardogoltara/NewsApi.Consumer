using Microsoft.Extensions.Configuration;
using NewsApi.Consumer.API.Models;
using Newtonsoft.Json;
using System.Text;

namespace NewsApi.Consumer.API.Services
{
    public class NewsApiWebClient
    {
        private readonly IConfiguration _configuration;
        private string _baseUrl;
        private string _apiKey;
        private string _appName;

        public NewsApiWebClient(IConfiguration configuration)
        {
            _configuration = configuration;
            _baseUrl = _configuration.GetSection("BaseUrl").Value;
            _apiKey = _configuration.GetSection("ApiKey").Value;
            _appName = _configuration.GetSection("AppName").Value;
        }

        public async Task<ResourceDto> GetAsync(string term, string dateFrom)
        {
            try
            {
                ResourceDto resourceDto = new ResourceDto();
                using (var httpClient = new HttpClient())
                {
                    string route = $"{_baseUrl}/v2/everything?q={term}&from={dateFrom}&sortBy=publishedAt&apiKey={_apiKey}";

                    httpClient.BaseAddress = new Uri(route);
                    httpClient.DefaultRequestHeaders.Add("User-Agent", _appName);
                    var response = await httpClient.GetAsync(route);

                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        resourceDto = JsonConvert.DeserializeObject<ResourceDto>(json);
                    }
                    else
                    {
                        resourceDto.ErrorMessage = await response.Content.ReadAsStringAsync();
                    }

                }

                return resourceDto;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
