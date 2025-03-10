using Microsoft.EntityFrameworkCore;
using MovieTransfer.Data;
using MovieTransfer.Repositories.Abstract;
using MovieTransfer.Repositories.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IOperationOnArray, ArrayOperations>();
builder.Services.AddHttpClient<IApiService, ApiService>();

var conn = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<MovieDbContext>(options =>
{
	options.UseSqlServer(conn);
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
