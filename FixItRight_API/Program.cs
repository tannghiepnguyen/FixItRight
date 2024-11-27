using FixItRight_API;
using FixItRight_API.Extension;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProblemDetails();
builder.Services.ConfigureDatabase(builder.Configuration);
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureManager();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureCors();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Host.UseSerilog((hostContext, configuration) =>
{
	configuration.ReadFrom.Configuration(hostContext.Configuration);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseExceptionHandler(opt => { });

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
