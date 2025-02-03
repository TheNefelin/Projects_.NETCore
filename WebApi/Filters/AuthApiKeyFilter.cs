﻿using ClassLibrary.Common;
using ClassLibrary.GamesGuideDapper.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filters
{
    public class AuthApiKeyFilter : IAsyncActionFilter
    {
        private readonly string ApiKeyHeaderName = "ApiKey";
        private readonly IApiKeyService _apiKeyService;

        public AuthApiKeyFilter(IApiKeyService apiKeyService)
        {
            _apiKeyService = apiKeyService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Intentar obtener el valor de ApiKey del header
            if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyHeaderName, out var apiKey) || string.IsNullOrEmpty(apiKey))
            {
                // Si ApiKey no está presente o es nula, retornar un 401
                context.Result = new UnauthorizedObjectResult(new ResponseApi<object> { 
                    IsSucces = false,
                    StatusCode = 401,
                    Message = "ApiKey es Requerida."
                });

                return;
            }

            // Llama al servicio para validar ApiKey en la base de datos
            var IsValid = await _apiKeyService.ValidateApiKey(apiKey);

            if (!IsValid)
            {
                context.Result = new UnauthorizedObjectResult(new ResponseApi<object>
                { 
                    IsSucces = false,
                    StatusCode = 401, 
                    Message = "ApiKey no Autorizado." 
                });

                return;
            }

            // Llamar a la siguiente acción si la ApiKey está presente
            await next();
        }
    }
}
