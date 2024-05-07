using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace StudentApi.Mediatr
{
    public static class Dependencies
    {
        public static IServiceCollection RegisterRequestHandlers(
            this IServiceCollection services)
        {
            return services
                .AddMediatR(c => c.RegisterServicesFromAssembly(typeof(Dependencies).Assembly));
        }
    }
}
