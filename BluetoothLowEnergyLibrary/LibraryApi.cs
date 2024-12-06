using Plugin.BLE.Abstractions.Contracts;

namespace BluetoothLowEnergyLibrary;

public class LibraryApi
{
    private readonly BleManager _bleManager = new();
    private readonly ProximityDetector _proximityDetector = new();
    private readonly SecureCommunication _secureCommunication = new();

    public async Task<IEnumerable<IDevice>> StartScanningAsync()
    {
        return await _bleManager.StartScanningAsync();
    }

    public async Task ConnectToDeviceAsync(IDevice device)
    {
        await _bleManager.ConnectToDeviceAsync(device);
    }

    public void SetProximityAlert(IDevice device)
    {
        _proximityDetector.CheckProximity(device);
        _proximityDetector.OnProximityDetected += (dev) => 
        {
            // Perform action when a device is within proximity
            System.Console.WriteLine($"Device {dev.Name} is within proximity.");
        };
    }

    public string EncryptMessage(string message, string key)
    {
        return _secureCommunication.EncryptData(message, key);
    }

    public string DecryptMessage(string encryptedMessage, string key)
    {
        return _secureCommunication.DecryptData(encryptedMessage, key);
    }
}
