using Contentful.Core;
using Contentful.Core.Configuration;
using KadelDemo.Models;
using KadelDemo.Models.Common;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System;

namespace KadelDemo.Components.Pages;

public partial class StaticPage
{
    private Product? product { get; set; }

    private ApplicationSettings? _applicationSettings;

    [Inject]
    private IConfiguration? _configuration { get; set; }

    protected override async Task OnInitializedAsync()
    {
		try
		{

            _applicationSettings = _configuration.GetSection(nameof(ApplicationSettings)).Get<ApplicationSettings>();
            string? baseUrl = _applicationSettings?.BaseURL;

            HttpClient client = new HttpClient();
            //string baseUrl = "https://localhost:44329/";
            var productStr = await client.GetStringAsync($"{baseUrl}api/contentful/getFirstEntry");

            if (!string.IsNullOrEmpty(productStr))
            {
                product = JsonConvert.DeserializeObject<Product>(productStr);
            }           
            
        }
		catch (Exception)
		{

			throw;
		}
		finally
		{

		}
    }

}

