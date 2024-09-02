using ESPresense.Models;

namespace ESPresense.Services;

public class DeviceManager
{
    public List<Device> Devices { get; } = new();

    public void UpdateDevice(Device device)
    {
        // Update the device in the collection
        var existingDevice = Devices.FirstOrDefault(d => d.Id == device.Id);
        if (existingDevice != null)
        {
            existingDevice.RssiAt1m = device.RssiAt1m;
            // Update other properties as needed
        }
        else
        {
            Devices.Add(device);
        }

        // Persist the changes (implement this method based on your storage mechanism)
        SaveChanges();
    }

    public Device? GetDevice(string id)
    {
        return Devices.FirstOrDefault(d => d.Id == id);
    }

    private void SaveChanges()
    {
        // Implement this method to persist the changes to your storage (database, file, etc.)
    }
}
