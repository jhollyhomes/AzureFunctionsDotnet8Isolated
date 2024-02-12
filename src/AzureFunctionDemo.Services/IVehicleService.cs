using AzureFunctionDemo.Services.Models;

namespace AzureFunctionDemo.Services;

public interface IVehicleService
{
    Vehicle CreateVehicle();
}