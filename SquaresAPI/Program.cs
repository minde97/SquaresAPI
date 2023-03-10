using SquaresAPI.Data;
using SquaresAPI.Managers;
using SquaresAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddSingleton<Storage>();
builder.Services.AddScoped<ISquareManager, SquareManager>();
builder.Services.AddScoped<IDataLayerService, DataLayerService>();
builder.Services.AddScoped<IPointsService, PointsService>();
builder.Services.AddScoped<ISquaresService, SquaresService>();

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
