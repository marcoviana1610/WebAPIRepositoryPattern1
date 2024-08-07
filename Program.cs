using Microsoft.EntityFrameworkCore;
using WebAPIRepositoryPattern.DataContext;
using WebAPIRepositoryPattern.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IFuncionarioInterface, FuncionarioService>();

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    // Configura o Kestrel para n�o usar HTTPS
    serverOptions.ListenAnyIP(5000); // Use uma porta n�o segura para HTTP
});

// banco de dados em mem�ria
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("FuncionariosDB"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
