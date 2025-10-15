using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace SotongStudio.Utilities.CameraStack
{
    public interface ICameraStackComponent
    {
        Camera Camera { get; }
        CameraStackType StackType { get; }
    }
    public class CameraStackComponent : MonoBehaviour, ICameraStackComponent
    {
        [Header("Main Camera")]
        [ReadOnly]
        [SerializeField]
        private Camera _mainCamera;
        [ReadOnly]
        [SerializeField]
        private Camera _camera;


        [SerializeField]
        private CameraStackType _stackType;

        public Camera Camera => _camera;
        public CameraStackType StackType => _stackType;
        private void OnValidate()
        {
            _camera = GetComponent<Camera>();
        }

        private void OnEnable()
        {
            var allCamera = FindObjectsByType<CameraStackComponent>(FindObjectsSortMode.None);
            foreach (var camera in allCamera)
            {
                if (camera.StackType == CameraStackType.Base)
                {
                    _mainCamera = camera.Camera;
                }
            }
            if (_stackType == CameraStackType.Overlay)
            {
                var data = _mainCamera.GetUniversalAdditionalCameraData();
                data.cameraStack.Add(Camera);
            }
        }

        private void OnDestroy()
        {
            var data = _mainCamera.GetUniversalAdditionalCameraData();
            data.cameraStack.Remove(Camera);
        }
    }
}
