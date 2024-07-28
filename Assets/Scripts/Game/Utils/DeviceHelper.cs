using UnityEngine;

public static class DeviceHelper
{
    private static float DeviceDiagonalSizeInInches()
    {
        float screenWidth = Screen.width / Screen.dpi;
        float screenHeight = Screen.height / Screen.dpi;
        float diagonalInches = Mathf.Sqrt(Mathf.Pow(screenWidth, 2) + Mathf.Pow(screenHeight, 2));

        return diagonalInches;
    }

    public static DeviceType GetDeviceType()
    {
        var aspectRatio = Mathf.Max(Screen.width, Screen.height) / Mathf.Min(Screen.width, Screen.height);
        var isTablet = (DeviceDiagonalSizeInInches() > 6.5f && aspectRatio < 2f);

        return isTablet ? DeviceType.Tablet : DeviceType.Phone;
    }
}

public enum DeviceType
{
    Tablet,
    Phone
}