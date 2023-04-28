using IsTakip.Core.DTOs;
using IsTakip.Service.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using System.Text.Json;

namespace IsTakip.API.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCostomException(this IApplicationBuilder app)
        {


            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var statusCode = exceptionFeature.Error switch
                    {
                        ClientSideException => 400,
                        NotFoundException => 404,
                        _ => 500

                    };
                    context.Response.StatusCode = statusCode;
                    var response = CustomResponseDTO<NoContentDTO>.Fail(statusCode, exceptionFeature.Error.Message);
                    await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(response));
                });
            });
        }
    }
}
