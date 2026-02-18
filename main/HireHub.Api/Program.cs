using HireHub.Api.Utils.Extensions;
using HireHub.Shared.Authentication;
using HireHub.Shared.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                })
            );

builder.Services.RegisterSwaggerGen();
builder.Services.RegisterServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();
app.MapGet("/health", () => Results.Ok("Healthy"));

app.UseHireHubRequestLogging();
app.UseHireHubGlobalException();
app.UseHireHubAuth();

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.MapControllers();

app.Run();
