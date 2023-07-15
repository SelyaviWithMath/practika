using Microsoft.EntityFrameworkCore;
using BMILibrary;
using WebApplicationPost.Repositories;
using WebApplicationPost.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(o => o.AddDefaultPolicy(b => b.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000").AllowCredentials()));
var connection = builder.Configuration.GetConnectionString("DefaultConnection"); //Assign с json
builder.Services.AddDbContext<ApplicationContext>(o => o.UseNpgsql(connection)); //Assign с json
builder.Services.AddTransient<IBmiRepository, BmiService>();//Магия ASP(Репрозитория и Сервайса)
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
