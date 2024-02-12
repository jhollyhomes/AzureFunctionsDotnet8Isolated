using AzureFunctionDemo.Services.Models;

namespace AzureFunctionDemo.Services;

public class VehicleService : IVehicleService
{
    public Vehicle CreateVehicle() 
    {
        return new Vehicle
        {
            Id = Guid.NewGuid().ToString(),
            RegistrationNumber = "ASB123Z",
            Make = "Ford",
            Model = "Fiesta"
        };
    }
}