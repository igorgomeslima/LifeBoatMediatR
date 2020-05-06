using MediatR;
using AutoMapper;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using LifeBoatMediatR.Application.Common.Behaviours;

namespace LifeBoatMediatR.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //services.AddMediatR(typeof(Startup));
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddSingleton<IMediator, CustomMediator>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));

            return services;
        }
    }
}
