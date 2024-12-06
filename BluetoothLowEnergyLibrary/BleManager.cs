using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;

namespace BluetoothLowEnergyLibrary;

public class BleManager
{
    private readonly IBluetoothLE _bluetoothLe = CrossBluetoothLE.Current;
    private readonly IAdapter _adapter = CrossBluetoothLE.Current.Adapter;

    public bool IsBluetoothAvailable => _bluetoothLe.IsAvailable;
    private bool IsBluetoothEnabled => _bluetoothLe.IsOn;

    public async Task<IEnumerable<IDevice>> StartScanningAsync()
    {
        if (!IsBluetoothEnabled)
            throw new InvalidOperationException("Bluetooth is not enabled.");

        var devices = new List<IDevice>();
        _adapter.DeviceDiscovered += (s, a) => devices.Add(a.Device);
        await _adapter.StartScanningForDevicesAsync();
        return devices;
    }

    public async Task ConnectToDeviceAsync(IDevice device)
    {
        await _adapter.ConnectToDeviceAsync(device);
    }

    public async Task DisconnectDeviceAsync(IDevice device)
    {
        await _adapter.DisconnectDeviceAsync(device);
    }

}