using LetsTrain.API.Startup;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerDocumentation();

builder.Services.RegisterDbContext(builder.Configuration);
builder.RegisterServices(); 

var app = builder.Build();

// Middlewares
app.ConfigureCors();
app.UseSwaggerDocs();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Seed roles e admin
using (var scope = app.Services.CreateScope())
{
    await DatabaseSeeder.SeedRolesAndAdmin(scope.ServiceProvider);
}

app.Run();
