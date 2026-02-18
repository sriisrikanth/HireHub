using HireHub.Api.Utils.Extensions;
using HireHub.Shared.Authentication;
using HireHub.Shared.Middleware;

var builder = WebApplication.CreateBuilder(args);

// ----------------------------------------------------
// ✅ Cloud Run PORT Binding (VERY IMPORTANT)
// ----------------------------------------------------
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(int.Parse(port));
});

// ----------------------------------------------------
// Add services to the container
// ----------------------------------------------------

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Custom registrations
builder.Services.RegisterSwaggerGen();
builder.Services.RegisterServices(builder.Configuration);

var app = builder.Build();

// ----------------------------------------------------
// Configure the HTTP request pipeline
// ----------------------------------------------------

// Swagger only in non-production
if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Health check endpoint (important for Cloud Run)
app.MapGet("/health", () => Results.Ok("Healthy"));

// Custom middleware
app.UseHireHubRequestLogging();
app.UseHireHubGlobalException();
app.UseHireHubAuth();

// ❌ Do NOT force HTTPS in Cloud Run Production
if (!app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
}

app.UseCors("AllowAll");

app.MapControllers();

app.Run();
