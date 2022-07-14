namespace API.Extensions;

public static class NewtonsoftJsonServicesExtensions
{
    public static IServiceCollection AddNewtonSoftDocumentation(this IServiceCollection services)
    {
        services.AddControllersWithViews()
                .AddNewtonsoftJson(options 
                    => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

        return services;
    }
}
