using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XboxGamesApi.Errors;

namespace XboxGamesApi.Extensions
{
    public static class ApplicationServicesExtension
    {

       public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            // caching needs to be singleton for any request

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.Configure<ApiBehaviorOptions>(options => {
                options.InvalidModelStateResponseFactory = ActionContext =>
                {
                    var erros = ActionContext.ModelState
                                                .Where(e => e.Value.Errors.Count > 0)
                                                .SelectMany(x => x.Value.Errors)
                                                .Select(x => x.ErrorMessage).ToArray();
                    var erroResponse = new APIValidationError
                    {
                        Errors = erros
                    };
                    return new BadRequestObjectResult(erroResponse);
                };
            });
            return services;
        }
    }
}
