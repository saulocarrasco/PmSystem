using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using PmSystem.FrontEnd.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped(provider => ActivatorUtilities.CreateInstance<HttpHandleClient<CustomerListViewModel>>(provider, builder.Configuration.GetSection("HttpParameters").Get<HttpParameters>().BaseUri));
builder.Services.AddScoped(provider => ActivatorUtilities.CreateInstance<HttpHandleClient<ProductListViewModel>>(provider, builder.Configuration.GetSection("HttpParameters").Get<HttpParameters>().BaseUri));
builder.Services.AddScoped(provider => ActivatorUtilities.CreateInstance<HttpHandleClient<CustomerCreateViewModel>>(provider, builder.Configuration.GetSection("HttpParameters").Get<HttpParameters>().BaseUri));
builder.Services.AddScoped(provider => ActivatorUtilities.CreateInstance<HttpHandleClient<ProductCreateViewModel>>(provider, builder.Configuration.GetSection("HttpParameters").Get<HttpParameters>().BaseUri));
builder.Services.AddScoped(provider => ActivatorUtilities.CreateInstance<HttpHandleClient<CustomerItemViewModel>>(provider, builder.Configuration.GetSection("HttpParameters").Get<HttpParameters>().BaseUri));
builder.Services.AddScoped(provider => ActivatorUtilities.CreateInstance<HttpHandleClient<CustomerItemListViewModel>>(provider, builder.Configuration.GetSection("HttpParameters").Get<HttpParameters>().BaseUri));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
