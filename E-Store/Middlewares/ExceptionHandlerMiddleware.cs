using BLL.Exceptions;
using System.Net;
using System.Text.Json;

namespace E_Store.Middlewares;

public class ExceptionHandlerMiddleware
{
	private readonly RequestDelegate _next;
	private readonly ILogger<ExceptionHandlerMiddleware> _logger;

	public ExceptionHandlerMiddleware(
		RequestDelegate next,
		ILogger<ExceptionHandlerMiddleware> logger)
	{
		_next = next;
		_logger = logger;
	}

	public async Task InvokeAsync(HttpContext context)
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

	private async Task HandleExceptionAsync(
		HttpContext context,
		Exception ex)
	{
		var statusCode = GetStatusCode(ex);
		var message = ex.Message;
		var stackTrace = ex.StackTrace;

		var exceptionResult = JsonSerializer.Serialize(new { error = message, stackTrace });

		context.Response.ContentType = "application/json";
		context.Response.StatusCode = (int)statusCode;

		if (statusCode == HttpStatusCode.InternalServerError)
			_logger.LogError(ex, message);

		await context.Response.WriteAsync(exceptionResult);
	}

	private static HttpStatusCode GetStatusCode(Exception exception) => exception switch
	{
		AlreadyExistException => HttpStatusCode.Conflict,
		BadHttpRequestException => HttpStatusCode.BadRequest,
		NotFoundException => HttpStatusCode.NotFound,
		ValidationException => HttpStatusCode.BadRequest,
		_ => HttpStatusCode.InternalServerError,
	};
}
