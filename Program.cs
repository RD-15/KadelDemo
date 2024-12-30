using KadelDemo.Components;
using KadelDemo.Services;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddHttpContextAccessor();
//builder.Services.AddRazorPages();
//builder.Services.AddServerSideBlazor()
//    .AddHubOptions(options => options.MaximumReceiveMessageSize = 1024 * 1024) // 1 MB
//    .AddCircuitOptions(options => options.DetailedErrors = true);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient("LocalApi", client => client.BaseAddress = new Uri("https://localhost:44329/"));

builder.Services.AddScoped<IKadelPropertyService, KadelPropertyServiceMock>();

builder.Services.AddMudServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();


app.UseRouting();
app.MapControllers();
app.UseAntiforgery();
//app.MapBlazorHub();
//app.MapFallbackToPage("/home");

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
