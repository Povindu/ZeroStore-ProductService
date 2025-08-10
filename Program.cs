
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProductService.DbContexts;
using ProductService.Services;
using ProductService.Settings;

var builder = WebApplication.CreateBuilder(args);


var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}");


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();



var authSettings = builder.Configuration
    .GetSection("Authentication")
    .Get<AuthenticationSettings>();


builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = authSettings.Issuer,
            ValidAudience = authSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(authSettings.SecretForKey))
        };
        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                Console.WriteLine($"Authentication failed: {context.Exception.Message}");
                return Task.CompletedTask;
            },
            OnTokenValidated = context =>
            {
                Console.WriteLine("Token validated");
                return Task.CompletedTask;
            }
        };
    }
);

builder.Services.AddDbContext<ProductServiceContext>(dbContextOptions =>
    dbContextOptions.UseSqlite(builder.Configuration["ConnectionStrings:ProductServiceDBConnectionString"]));

builder.Services.AddScoped<IProductServiceRepository, ProductServiceRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ProductServiceContext>();
    dbContext.Database.Migrate();
}



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
