using UnityEngine;
using UnityEngine.UI;

namespace SlotMachine.Game.Utils
{
    public class CameraRationAspectHelper : MonoBehaviour
    {
        [SerializeField]
        private Camera _camera;
       

        private int _resolutionX = 16;
        private int _resolutionY = 9;

        void Awake()
        {
            var canvasScaler = transform.GetComponent<CanvasScaler>();
            if (canvasScaler == null)
            {
                return;
            }

            if (DeviceHelper.GetDeviceType() == DeviceType.Tablet)
            {
                canvasScaler.matchWidthOrHeight = 0;
            }

            if (DeviceHelper.GetDeviceType() == DeviceType.Phone)
            {
                canvasScaler.matchWidthOrHeight = 1;
                float screenRatio = (float)Screen.width / Screen.height;
                float bestRatio = (float)_resolutionX / _resolutionY;

                _camera.rect = screenRatio <= bestRatio
                    ? new Rect(0, (1f - screenRatio / bestRatio) / 2f, 1, screenRatio / bestRatio)
                    : new Rect((1f - bestRatio / screenRatio) / 2f, 0, bestRatio / screenRatio, 1)
                ;
            }
         
        }
    }
}