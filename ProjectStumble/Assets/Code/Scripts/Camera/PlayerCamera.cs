using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;

    private void Start()
    {
        if (CameraManager.Instance != null)
            CameraManager.Instance.SetUpCamera(_camera, _virtualCamera);
    }
}
