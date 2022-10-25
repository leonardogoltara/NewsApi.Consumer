using Newtonsoft.Json;

namespace NewsApi.Consumer.API.Models
{
    public class ResourceDto
    {
        [JsonProperty("articles")]
        public IEnumerable<ArticleDto> ArticleDto { get; set; }

        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }
        public bool HasError { get { return !string.IsNullOrEmpty(ErrorMessage); } }
    }
}
