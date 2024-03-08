using Pet.Services.General.Interfaces;

namespace Pet.Services.General;
public class MaintenanceService : IMaintenanceService
{
    public void SyncInventory()
    {
        Console.WriteLine("Syncing inventory...");
    }
}