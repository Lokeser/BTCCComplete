using BancaTCC.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o DbContext ao cont�iner de servi�os com a string de conex�o "bancaConnection".
builder.Services.AddDbContext<BancaTCCContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("bancaConnection")));

// Adiciona servi�os de controle e exibi��o.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configura��o do pipeline de requisi��es HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection(); // Redireciona requisi��es HTTP para HTTPS.
app.UseStaticFiles();      // Permite servir arquivos est�ticos.

app.UseRouting();          // Configura o roteamento.

app.UseAuthorization();    // Adiciona a autoriza��o ao pipeline.

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // Define a rota padr�o.

app.Run();
