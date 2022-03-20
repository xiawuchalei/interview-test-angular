using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace interview_test_angular.Mediatr
{
    public static class Dependencies
    {
        public static IServiceCollection RegisterRequestHandlers(
            this IServiceCollection services)
        {
            return services
                .AddMediatR(typeof(Dependencies).Assembly);
        }
    }
}
