var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpClient();

builder.Services.AddControllers().AddNewtonsoftJson();

var app = builder.Build();

app.MapControllers();

app.MapGet("/", () => "Hello World2!");

app.Run();
