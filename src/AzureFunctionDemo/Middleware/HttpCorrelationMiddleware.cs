using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.Azure.Functions.Worker;

namespace AzureFunctionDemo.Middleware;
internal sealed class HttpCorrelationIdMiddleware : IFunctionsWorkerMiddleware
{
    private const string CorrelationId = "x-correlationId";
    public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
    {
        var requestData = await context.GetHttpRequestDataAsync();

        var correlationId = requestData!.Headers.TryGetValues(CorrelationId, out var values)
            ? values.First()
            : Guid.NewGuid().ToString();

        await next(context);

        context.GetHttpResponseData()?.Headers.Add(CorrelationId, correlationId);
    }
}
