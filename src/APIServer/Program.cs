using TSN.Identity;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.ConfigureAuthentication();
builder.ConfigureAuthorization();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/auth", () => "Autenticado!")
    .RequireAuthorization();

app.MapControllers();

app.Run();
