using Microsoft.EntityFrameworkCore;
using Serilog.Context;
using UmbracoBlogFinal1.App_Code.Composers;
using UmbracoBlogFinal1.App_Code.CustomDBContexts;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.CreateUmbracoBuilder()
    .AddBackOffice()
    .AddWebsite()
.AddDeliveryApi()
.AddComposers()
.AddCustomNotificationServices()
.Build();

builder.Services.AddUmbracoDbContext<CustomDBContext>(options =>
{
    options.UseSqlServer("Server=EVS01LAP7010\\MSSQLSERVER1;Database=UmbracoCms1;Integrated Security=true;TrustServerCertificate=true;");
    //If you are using SQlite, replace UseSqlServer with UseSqlite
});

WebApplication app = builder.Build();

await app.BootUmbracoAsync();


app.UseUmbraco()
    .WithMiddleware(u =>
    {
        u.UseBackOffice();
        u.UseWebsite();
    })
    .WithEndpoints(u =>
    {
        u.UseInstallerEndpoints();
        u.UseBackOfficeEndpoints();
        u.UseWebsiteEndpoints();
    });

await app.RunAsync();
