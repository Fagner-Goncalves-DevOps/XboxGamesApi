using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XboxGamesApi.Extensions
{
    public static class SwaggerServiceExtension
    {

        public static IServiceCollection AddSwaggerDoc( this IServiceCollection services) 
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "XboxGamesApi", Version = "v1" });
                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "JWT authentication scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };
                c.AddSecurityDefinition("Bearer", securitySchema);
                var securityRequirement = new OpenApiSecurityRequirement {
                    {securitySchema, new[] { "Bearer"}}};
                c.AddSecurityRequirement(securityRequirement);
            });
            return services;

        }

        public static IApplicationBuilder UseSwaggerDoc(this IApplicationBuilder app) 
        {
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "XboxGamesApi");
            });
            return app;

        }




    }
}

