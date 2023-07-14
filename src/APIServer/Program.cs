using TSN.APIServer.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureIdentity();

builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapControllers();

app.Run();
