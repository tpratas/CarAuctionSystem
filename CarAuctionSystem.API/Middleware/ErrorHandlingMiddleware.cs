using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace CarAuctionSystem.API.Middleware;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

	public ErrorHandlingMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	public async Task Invoke(HttpContext context)
	{
		try
		{
			await _next(context);
		}
		catch (Exception ex)
		{
			await HandleExceptionAsync(context, ex);
	
		}
	}

	private static Task HandleExceptionAsync(HttpContext context, Exception exception)
	{
        var code = HttpStatusCode.InternalServerError;

        var problemDetails = new ProblemDetails
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
            Title = "An error occured while processing the request.",
            Status = (int)HttpStatusCode.InternalServerError
        };

		var result = JsonConvert.SerializeObject(problemDetails);
		context.Response.ContentType = "application/json";
		context.Response.StatusCode = (int)code;
        return context.Response.WriteAsync(result);
    }
}
