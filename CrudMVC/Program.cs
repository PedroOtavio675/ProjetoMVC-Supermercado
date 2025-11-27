using Microsoft.EntityFrameworkCore;
using CrudMVC.Data;
using CrudMVC.Ropositorio;
using CrudMVC.Controllers;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
//Obter a string de conexão 
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. Adicionar o DbContext
builder.Services.AddDbContext<BancoContext>(options =>
    // Usar o provedor Npgsql e passar a string de conexão
    options.UseNpgsql(connectionString)
   
);
builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
builder.Services.AddScoped<IVendaRepositorio, VendaRepositorio>();


builder.Services.AddDistributedMemoryCache(); // Cache necessário para a Sessão
builder.Services.AddSession(options => // Configuração da Sessão
{
    options.Cookie.HttpOnly = true;
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});

// ...
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();


app.UseAuthorization();

app.MapStaticAssets();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
