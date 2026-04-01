using Microsoft.EntityFrameworkCore;
using CourseManagement.Api.Data;
using CourseManagement.Api.Repositories; // We will create this next
using CourseManagement.Api.Interfaces; // We will create this next
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddDbContext<CourseDbContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("CourseDbConnection")));
builder.Services.AddScoped<ICourseRepository, CourseRepository>(); // For repository pattern
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at <https://aka.ms/aspnetcore/swashbuckle>
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Apply migrations at startup (optional, good for development)
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<CourseDbContext>();
        context.Database.Migrate(); // This will create the DB and apply migrations if they haven't been
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating the database.");
    }
}
app.UseHttpsRedirection();
app.UseAuthorization();

app.Run();