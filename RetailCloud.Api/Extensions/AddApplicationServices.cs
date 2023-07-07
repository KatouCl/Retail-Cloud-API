using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using RetailCloud.Api.Errors;
using RetailCloud.Core.Interfaces;
using RetailCloud.Infrastracture.Repository;

namespace RetailCloud.Api.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.Configure<ApiBehaviorOptions>(options =>
                options.InvalidModelStateResponseFactory = ActionContext =>
                {
                    var error = ActionContext.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .SelectMany(e => e.Value.Errors)
                        .Select(e => e.ErrorMessage).ToArray();
                    var errorResponse = new APIValidationErrorResponse
                    {
                        Errors = error
                    };
                    return new BadRequestObjectResult(error);
                }
            );

            return services;
        }
    }
}