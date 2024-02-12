using AzureFunctionDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Newtonsoft.Json;

namespace AzureFunctionDotNetDemo
{
    public class HttpPopulateQueue(IVehicleService vehicleService)
    {
        [Function("HttpPopulateQueue")]
        public DispatchToLocalQueue Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            var vehicle = vehicleService.CreateVehicle();

            var serialisedVehicle = JsonConvert.SerializeObject(vehicle);

            var output = new DispatchToLocalQueue();
            output.Messages.Add(serialisedVehicle);

            return output;
        }

        public class DispatchToLocalQueue()
        {
            [QueueOutput("queue-messages-json")]
            public List<string> Messages { get; set; } = [];
        }
    }
}
