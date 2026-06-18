using YG;

public class DeviceChecker
{
    public string GetDeviceType()
    {
        string deviceType = YG2.envir.deviceType;
        return deviceType;
    }
}
