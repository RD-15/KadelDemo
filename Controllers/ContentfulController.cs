using Contentful.Core.Configuration;
using Contentful.Core;
using KadelDemo.Models.Common;
using Microsoft.AspNetCore.Mvc;
using KadelDemo.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KadelDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentfulController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly ApplicationSettings? _applicationSettings;

        public ContentfulController(IConfiguration configuration)
        {
            _configuration = configuration;
            _applicationSettings = _configuration.GetSection(nameof(ApplicationSettings)).Get<ApplicationSettings>();
        }


        /// <summary>
        /// Get data from Contentful CMS for static page.
        /// </summary>        
        /// <returns></returns>
        [HttpGet("getFirstEntry")]
        public async Task<ActionResult<Product>> GetFirstEntry()
        {
            var httpClient = new HttpClient();
            var options = new ContentfulOptions
            {
                DeliveryApiKey = _applicationSettings?.DeliveryApiKey,
                PreviewApiKey = _applicationSettings?.PreviewApiKey,
                SpaceId = _applicationSettings?.SpaceId
            };

            var client = new ContentfulClient(httpClient, options);

            string? productId = _applicationSettings?.FirstEntry;

            var entry = await client.GetEntry<Product>(productId);

            if(entry != null)
            {
                return entry;
            }
            else
            {
                return NotFound();
            }
            
        }

        /// <summary>
        /// Get data from Contentful CMS for hybrid page.
        /// </summary>        
        /// <returns></returns>
        [HttpGet("getSecondEntry")]
        public async Task<ActionResult<Product>> GetSecondEntry()
        {
            var httpClient = new HttpClient();
            var options = new ContentfulOptions
            {
                DeliveryApiKey = _applicationSettings?.DeliveryApiKey,
                PreviewApiKey = _applicationSettings?.PreviewApiKey,
                SpaceId = _applicationSettings?.SpaceId
            };

            var client = new ContentfulClient(httpClient, options);

            string? productId = _applicationSettings?.SecondEntry;

            var entry = await client.GetEntry<Product>(productId);

            if (entry != null)
            {
                return entry;
            }
            else
            {
                return NotFound();
            }

        }
       
    }
}
