using Cinemachine;
using UnityEngine;

public class CameraManager : SceneSingleton<CameraManager>
{
    private int _currPlayerIndex;

    [SerializeField] private string _virtualCamera1Layer;
    [SerializeField] private string _virtualCamera2Layer;
    [SerializeField] private LayerMask _camera1CullingMask;
    [SerializeField] private LayerMask _camera2CullingMask;

    public void SetUpCamera(Camera camera, CinemachineVirtualCamera virtualCamera)
    {
        _currPlayerIndex++;
        if (_currPlayerIndex == 1)
        {
            virtualCamera.gameObject.layer = LayerMask.NameToLayer(_virtualCamera1Layer);
            camera.cullingMask = _camera1CullingMask;
        }
        else if (_currPlayerIndex == 2)
        {
            virtualCamera.gameObject.layer = LayerMask.NameToLayer(_virtualCamera2Layer);
            camera.cullingMask = _camera2CullingMask;
        }
    }
}
