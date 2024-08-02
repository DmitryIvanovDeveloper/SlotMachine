using System.Runtime.InteropServices;
using UnityEngine;

public class Vibration : MonoBehaviour
{
#if UNITY_WEBGL
    [DllImport("__Internal")]
#endif

    private static extern void Vibrate(int ms);

    public void OnTap()
    {
#if UNITY_WEBGL
            Vibrate(170);
#else
          Handheld.Vibrate();
#endif
    }
}