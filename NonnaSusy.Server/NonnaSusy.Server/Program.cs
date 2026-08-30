using Microsoft.EntityFrameworkCore;
using NonnaSusy.DB.Data;
using NonnaSusy.DB.Data.Entities;
using NonnaSusy.Repositorio.Repositorio;
using NonnaSusy.Server.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IRepositorio<Cliente>, Repositorio<Cliente>>();
builder.Services.AddScoped<IRepositorio<Producto>, Repositorio<Producto>>();
builder.Services.AddScoped<IPedidoRepositorio, PedidoRepositorio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(NonnaSusy.Server.Client._Imports).Assembly);

app.MapControllers();

app.Run();
