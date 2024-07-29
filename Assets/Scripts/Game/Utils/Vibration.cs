using System.Runtime.InteropServices;
using UnityEngine;

public class Vibration : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void Vibrate(int ms);

    public void OnTap()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
            Vibrate(170);
#else
#endif
    }
}