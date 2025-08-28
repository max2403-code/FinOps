var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
builder.Services.AddGrpcHealthChecks();

var app = builder.Build();

var isDevelopment = app.Environment.IsDevelopment();

app.Run();
