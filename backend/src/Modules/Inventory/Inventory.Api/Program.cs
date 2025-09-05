using FinOps.Modules.Inventory.Api.Extensions;
using Inventory.Database;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext(builder.Configuration);

builder.Services.AddGrpc();
builder.Services.AddGrpcHealthChecks();

var app = builder.Build();

app.DbMigrate();

var isDevelopment = app.Environment.IsDevelopment();

app.Run();
