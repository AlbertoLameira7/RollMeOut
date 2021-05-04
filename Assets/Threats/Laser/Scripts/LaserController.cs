using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 2f;

    void FixedUpdate()
    {
        transform.Rotate(Vector3.up * _rotationSpeed * Time.fixedDeltaTime);
    }
}
