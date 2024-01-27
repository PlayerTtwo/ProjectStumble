using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushForces : MonoBehaviour
{
    [SerializeField] private float _power = 10f;
    [SerializeField] private float _radius = 2f;

    private Rigidbody _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponentInParent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Trap"))
            _rigidBody.AddExplosionForce(_power, transform.position, _radius, 3.0F);
    }
}
