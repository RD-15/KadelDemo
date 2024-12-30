using Contentful.Core;
using Contentful.Core.Configuration;
using KadelDemo.Models;
using KadelDemo.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Newtonsoft.Json;
using System;

namespace KadelDemo.Components.Pages;

public partial class Search
{   

    public string searchStr { get; set; } = string.Empty;

    private List<PropertyItem> properties { get; set; } = new();

    private List<PropertyItem> filteredProperties { get; set; } = new();

    [Inject]
    private IKadelPropertyService? KadelPropertyService { get; set; }

    [Inject]
    protected ISnackbar Snackbar { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
       
    }

    private async Task SearchProperty()
    {
        properties = await KadelPropertyService.GetPropertyAsync();

        if(properties != null && !string.IsNullOrEmpty(searchStr))
        {
            //properties = (List<PropertyItem>)properties.ToList().Where(x => x.Description.StartsWith(searchStr));
            filteredProperties = properties
                        .Where(x => x.Description.ToUpper().Trim().StartsWith(searchStr.ToUpper().Trim()))
                        .ToList();           
        }
        else
        {
            Snackbar.Add("Please enter description! ", Severity.Info);
        }
        

        StateHasChanged();
    }

}