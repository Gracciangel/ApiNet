using DAL.Contexto;
using DAL.Interfaces.Cards;
using DAL.Interfaces.Usuarios;
using DAL.Services.CardServices;
using DAL.Services.UserServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
var contection = builder.Configuration.GetConnectionString("connectionString");
builder.Services.AddDbContext<ContextDB>(
    context => context.UseSqlServer(contection));

builder.Services.AddScoped<IUsers, UserServices>(); 
builder.Services.AddScoped<ICard, CardServices>();  


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AlowAll",
        builder => builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
        ); 
       
}); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AlowAll");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
