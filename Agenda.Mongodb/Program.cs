using Agenda.Mongodb.Service;
using Framework.Agenda;
using Agenda.Mappers;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseKestrel();
builder.WebHost.UseUrls("http://0.0.0.0:5000");
builder.WebHost.CaptureStartupErrors(true);
builder.WebHost.UseSetting(WebHostDefaults.DetailedErrorsKey, "true");

// Add services to the container.
builder.Services.AddLogging(logger =>
{
    logger.AddConsole();
    logger.AddDebug();
    logger.SetMinimumLevel(LogLevel.Warning);
});
builder.Services.AddMemoryCache();
builder.Services.AddMongoDependencies();

builder.Services.AddScoped<IAgendaService, AgendaService>();
builder.Services.AddAutoMapper(typeof(BsonAgendaProfile));


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

app.UseAuthorization();

app.MapControllers();

app.Run();