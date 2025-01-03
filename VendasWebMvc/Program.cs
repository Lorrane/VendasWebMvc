using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VendasWebMvc.Data;
var builder = WebApplication.CreateBuilder(args);
/*builder.Services.AddDbContext<VendasWebMvcContext>(options =>
    options.UseMySql(Configuration.GetConnectionString("VendasWebMvccontext"), builder =>
    builder.MigrationsAssembly("VendasWebMvc"));*/

builder.Services.AddDbContext<VendasWebMvcContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("VendasWebMvcContext"), // Acessando corretamente a configuração
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("VendasWebMvcContext")) // Detecta automaticamente a versão do MySQL
    )
);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
