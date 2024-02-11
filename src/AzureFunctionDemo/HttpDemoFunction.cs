using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace AzureFunctionDemo;

public class HttpDemoFunction(ILogger<HttpDemoFunction> logger)
{
    [Function("HttpDemoFunction")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
    {
        logger.LogInformation("C# HTTP trigger function processed a request.");


        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

        await response.WriteStringAsync("Header should have correlation id");

        return response;
    }

}

