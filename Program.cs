using Microsoft.EntityFrameworkCore;
using mini_app_pay.Models;

var builder = WebApplication.CreateBuilder(args);

// Add Database Connection
builder.Services.AddDbContext<PaymentDetailContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ?? ????? ???? CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        builder => builder.WithOrigins("http://localhost:4200") // ???? ?????????
                          .AllowAnyMethod()
                          .AllowAnyHeader()
                          .AllowCredentials()); // ?? ???? ???? ?? ????? ???? ?? ????? ????
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ?? ???? ???? CORS ??? ?? UseAuthorization
app.UseCors("AllowAngularApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
