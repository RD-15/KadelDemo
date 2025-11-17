using Contentful.Core.Configuration;
using Contentful.Core;
using KadelDemo.Models.Common;
using Microsoft.AspNetCore.Mvc;
using KadelDemo.Models;
using KadelDemo.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KadelDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentfulController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly ApplicationSettings? _applicationSettings;
        private readonly IKadelPropertyService _kadelPropertyService;

        public ContentfulController(IConfiguration configuration, IKadelPropertyService kadelPropertyService)
        {
            _configuration = configuration;
            _applicationSettings = _configuration.GetSection(nameof(ApplicationSettings)).Get<ApplicationSettings>();
            _kadelPropertyService = kadelPropertyService;
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

        /// <summary>
        /// Create a new property.
        /// </summary>
        /// <param name="property">Property to create</param>
        /// <returns></returns>
        [HttpPost("createProperty")]
        public async Task<ActionResult<PropertyItem>> CreateProperty([FromBody] PropertyItem property)
        {
            var createdProperty = await _kadelPropertyService.CreatePropertyAsync(property);
            return Ok(createdProperty);
        }
       
    }
}
