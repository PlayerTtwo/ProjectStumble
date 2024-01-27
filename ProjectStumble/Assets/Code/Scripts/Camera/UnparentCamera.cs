using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnparentCamera : MonoBehaviour
{
    private void Start()
    {
        transform.parent = null;
    }
}
