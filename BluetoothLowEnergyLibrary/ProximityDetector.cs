using Plugin.BLE.Abstractions.Contracts;
using System;

namespace BluetoothLowEnergyLibrary;

public class ProximityDetector
{
    private const int ProximityThreshold = -70; // RSSI threshold for proximity alert

    public event Action<IDevice>? OnProximityDetected;

    public void CheckProximity(IDevice device)
    {
        if (device.Rssi >= ProximityThreshold)
        {
            OnProximityDetected?.Invoke(device);
        }
    }
}