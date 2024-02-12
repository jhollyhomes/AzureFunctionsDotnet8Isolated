using Azure.Storage.Queues.Models;
using AzureFunctionDemo.Services.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzureFunctionDotNetDemo
{
    public class ConsumeQueue(ILogger<ConsumeQueue> logger)
    {
        [Function(nameof(ConsumeQueue))]
        public void Run([QueueTrigger("queue-messages-json", Connection = "")] QueueMessage message)
        {
            var bodyString = message.Body.ToString();

            var deserializeVehicle = JsonConvert.DeserializeObject<Vehicle>(bodyString);

            if (deserializeVehicle == null)
            {
                logger.LogError("Unable to deserialize object");
                return;
            }

            if (deserializeVehicle.Make != "Ford")
            {
                logger.LogError("Unable to deserialize object");
                return;
            }

            logger.LogInformation("Object deserialize successfully");
        }
    }
}
