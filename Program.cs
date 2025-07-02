using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// configurar autenticação por cookie
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/api/auth/login"; // Define the login path
        options.LogoutPath = "/api/auth/logout"; // Define the logout path
        options.Cookie.HttpOnly = true; // Set the cookie to be HTTP only
        options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest; // Use secure cookies
        options.AccessDeniedPath = "/api/auth/denied"; // Define the access denied path
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Set cookie expiration time
        options.SlidingExpiration = true; // Enable sliding expiration
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Weather API V1");
        c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
    });
}

app.UseHttpsRedirection();

app.UseAuthentication(); // Enable authentication middleware
app.UseAuthorization();

app.MapControllers();
app.Run();