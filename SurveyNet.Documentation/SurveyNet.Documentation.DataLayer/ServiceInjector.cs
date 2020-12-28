using System;
using Microsoft.Extensions.DependencyInjection;
using SurveyNet.Documentation.DataLayer.Interfaces;
using SurveyNet.Documentation.DataLayer.Repositories;

namespace SurveyNet.Documentation.DataLayer {
    public static class ServiceInjector {
        public static IServiceCollection AddRepositories(this IServiceCollection services, Func<ConnectionOptions> config) {
            services.AddSingleton(config());
            services.AddScoped<ISurveyRepository, SurveySqlRepository>();

            return services;
        }
    }
}