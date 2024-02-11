using AzureFunctionDemo.Middleware;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults(worker =>
    {
        worker.UseWhen<HttpCorrelationIdMiddleware>((context) =>
        {
            return context.FunctionDefinition.InputBindings.Values
                .First(a => a.Type.EndsWith("Trigger")).Type == "httpTrigger";
        });
    })
    .Build();

host.Run();
