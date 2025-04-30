namespace LetsTrain.API.Startup
{
    public static class CorsConfig
    {
        public static void ConfigureCors(this WebApplication app)
        {
            app.UseCors(policy =>
                policy.WithOrigins("http://localhost:4200") // origem do Angular
                      .AllowAnyMethod()
                      .AllowAnyHeader()
                      .AllowCredentials());
        }
    }

}
