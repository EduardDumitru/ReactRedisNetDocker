var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks();
var app = builder.Build();

app.UseStaticFiles();

app.MapHealthChecks("/health");
app.MapFallbackToFile("index.html");

app.Run();
