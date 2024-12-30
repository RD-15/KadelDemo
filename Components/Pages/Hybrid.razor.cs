using Contentful.Core;
using Contentful.Core.Configuration;
using KadelDemo.Models;
using KadelDemo.Models.Common;
using KadelDemo.Services;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System;

namespace KadelDemo.Components.Pages;

public partial class Hybrid
{
    
    private ApplicationSettings? _applicationSettings;

    private List<PropertyItem> properties { get; set; } = new();

    private Product? product { get; set; }

    [Inject]
    private IKadelPropertyService? KadelPropertyService { get; set; }

    [Inject]
    private IConfiguration? _configuration { get; set; }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            _applicationSettings = _configuration.GetSection(nameof(ApplicationSettings)).Get<ApplicationSettings>();
            string? baseUrl = _applicationSettings?.BaseURL;

            HttpClient client = new HttpClient();
           // string baseUrl = "https://localhost:44329/";
            var productStr = await client.GetStringAsync($"{baseUrl}api/contentful/getSecondEntry");

            if (!string.IsNullOrEmpty(productStr))
            {
                product = JsonConvert.DeserializeObject<Product>(productStr);
            }

            //Get data using mock API
            properties = await KadelPropertyService.GetPropertyAsync();            
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

