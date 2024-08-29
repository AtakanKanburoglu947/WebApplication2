namespace WebApplication2
{
    public static class ServiceConfiguration
    {
        public static void Configure(this IServiceCollection services)
        {
            services.AddSingleton<IDateTime,SystemDateTime>();
        }
    }
}
