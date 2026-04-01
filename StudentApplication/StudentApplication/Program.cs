using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StudentApplication.Data;
using StudentApplication.Repositories;
using StudentApplication.Repositories.Interfaces;
using System.Text;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); // Ensure this is present for API controllers
builder.Services.AddSwaggerGen(); // Ensure this is present for API controllers
// ===== JWT Authentication Configuration START =====
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]!)) // Ensure null check or assertion for SecretKey
    };
});
builder.Services.AddAuthorization();
// ===== JWT Authentication Configuration END =====
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Ensure this is present
    app.UseSwaggerUI(); // Ensure this is present
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore - hsts.
     app.UseHsts(); // Consider enabling HSTS
}
app.UseHttpsRedirection(); // Typically good to have
app.UseStaticFiles();
app.UseRouting();
// ===== Authentication & Authorization Middleware START =====
app.UseAuthentication(); // <-- Add this: IMPORTANT - Must be before UseAuthorization
app.UseAuthorization();
// ===== Authentication & Authorization Middleware END =====
app.MapControllerRoute(
 name: "default",
 pattern: "{controller=Student}/{action=Index}/{id?}");
// This will map attribute-routed API controllers
app.MapControllers(); // <-- Add this if not already present, for API controllers
app.Run();
