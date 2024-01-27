using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCullingLayers : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] private LayerMask _cullingLayers;

    private void Start()
    {
        _camera.cullingMask = _cullingLayers;
    }
}
