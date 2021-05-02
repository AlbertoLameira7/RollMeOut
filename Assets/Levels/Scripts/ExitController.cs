using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitController : MonoBehaviour
{
    [SerializeField] private int _sceneToLoad;
    private bool _isOpen;

    void Awake()
    {
        _isOpen = false;
    }

    void OnEnable()
    {
        GameManager.EnableExit += OpenExit;
    }

    private void OnDisable()
    {
        GameManager.EnableExit -= OpenExit;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball") && _isOpen)
        {
            SceneManager.LoadScene(_sceneToLoad);
        }
    }

    void OpenExit()
    {
        _isOpen = true;
    }
}
