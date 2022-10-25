using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsApi.Consumer.API.ExtensionsMethods;
using NewsApi.Consumer.API.Models;
using NewsApi.Consumer.API.Services;
using Newtonsoft.Json;
using System.Text;

namespace NewsApi.Consumer.API.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("article")]
    public class ArticleController : Controller
    {
        private readonly NewsApiWebClient _newsApiWebClient;

        public ArticleController(NewsApiWebClient newsApiWebClient)
        {
            _newsApiWebClient = newsApiWebClient;
        }

        /// <summary>
        /// Consulta de Artigos.
        /// </summary>
        /// <param name="term">Termo de busca. Exemplo: tesla</param>
        /// <param name="dateFrom">Data de criação. Exemplo: 2022-09-25</param>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResourceDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResourceDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResourceDto))]
        public async Task<IActionResult> Get(string term, string dateFrom)
        {
            try
            {
                var resource = await _newsApiWebClient.GetAsync(term, dateFrom);
                if (resource.HasError)
                {
                    return BadRequest(resource);
                }
                else
                {
                    return Ok(resource);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ResourceDto() { 
                        ErrorMessage = ex.GetCompleteMessage() 
                    });
            }
        }
    }
}
