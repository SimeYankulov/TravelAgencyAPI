using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using TravelAgencyAPI.Data;
using TravelAgencyAPI.Repositories;
using TravelAgencyAPI.Repositories.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Added
builder.Services.AddDbContextPool<TravelAgencyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TravelAgencyConnection"))
    );

builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<IHolidayRepository, HolidayRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
//


var app = builder.Build();


// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Explicitly allowing the front-end to access resources 
// from link from requiroments
app.UseCors(policy =>
    policy.WithOrigins("http://localhost:5173/", "http://localhost:5173/")
    .AllowAnyMethod()
    .WithHeaders(HeaderNames.ContentType)
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapDefaultControllerRoute();

app.Run();
