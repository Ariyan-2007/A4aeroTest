using A4aeroTest.Services.Implementations;
using A4aeroTest.Services.Interfaces;
using A4aeroTest.Utilities;

var builder = WebApplication.CreateBuilder(args);


var configurationSetting = builder.Configuration.GetSection("TboAPISettings");

// Add services to the container.
builder.Services.Configure<TBOApiSettings>(configurationSetting);
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IFlightSearchService, FlightSearchService>();
builder.Services.AddHttpClient<TBOApiClient>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
