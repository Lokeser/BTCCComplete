using BancaTCC.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o DbContext ao contêiner de serviços com a string de conexão "bancaConnection".
builder.Services.AddDbContext<BancaTCCContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("bancaConnection")));

// Adiciona serviços de controle e exibição.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configuração do pipeline de requisições HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection(); // Redireciona requisições HTTP para HTTPS.
app.UseStaticFiles();      // Permite servir arquivos estáticos.

app.UseRouting();          // Configura o roteamento.

app.UseAuthorization();    // Adiciona a autorização ao pipeline.

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // Define a rota padrão.

app.Run();
