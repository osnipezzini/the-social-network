using TSN.Identity;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.ConfigureAuthentication();
builder.ConfigureAuthorization();

app.MapGet("/", () => "Hello World!");

app.Run();
