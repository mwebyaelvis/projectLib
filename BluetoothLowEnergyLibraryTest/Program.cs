using BluetoothLowEnergyLibrary;

namespace BluetoothLowEnergyLibraryTest;

internal abstract class Program
{
    static async Task Main(string[] args)
    {
        var api = new LibraryApi();

        // Start BLE scanning
        var devices = await api.StartScanningAsync();
        foreach (var device in devices)
        {
            Console.WriteLine($"Found device: {device.Name}");
            api.SetProximityAlert(device);
        }

        // Encrypt and decrypt a message
        var key = "Keith_123";
        var encryptedMessage = api.EncryptMessage("Hello Passenger", key);
        Console.WriteLine($"Encrypted Message: {encryptedMessage}");

        string decryptedMessage = api.DecryptMessage(encryptedMessage, key);
        Console.WriteLine($"Decrypted Message: {decryptedMessage}");
    }
}