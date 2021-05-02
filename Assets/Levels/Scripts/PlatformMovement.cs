using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector3 _vec;
    private Quaternion _startRotation;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        float inputZ = Input.GetAxis("Horizontal") * 10f * -1;
        float inputX = Input.GetAxis("Vertical") * 10f;

        transform.rotation = Quaternion.Euler(inputX, 0, inputZ) * _startRotation;
    }
}
