using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    [SerializeField] private float _cameraSmoothing = 5f;

    private GameObject _target;
    private Vector3 _offset;

    void OnEnable()
    {
        GameManager.LinkBallToCamera += AddBallToCamera;
    }

    private void OnDisable()
    {
        GameManager.LinkBallToCamera -= AddBallToCamera;
    }

    void LateUpdate()
    {
        if (_target)
        {
            Vector3 targetCamPos = _target.transform.position + _offset;
            transform.position = Vector3.Lerp(transform.position, targetCamPos, _cameraSmoothing * Time.deltaTime);
        }

    }

    void AddBallToCamera(GameObject target)
    {
        _target = target;
        CameraInit();
    }
    
    void CameraInit()
    {
        _offset = transform.position - _target.transform.position;
    }
}