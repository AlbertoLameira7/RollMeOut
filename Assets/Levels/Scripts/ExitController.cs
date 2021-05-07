using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ExitController : MonoBehaviour
{
    public static Action SaveTimer;
    public static Action PlayEndLevelAnimation;
    public float transitionTime = 1f;

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
            SaveTimer();
            PlayEndLevelAnimation();
            StartCoroutine(FadeManager.instance.LoadLevel(_sceneToLoad));
        }
    }

    void OpenExit()
    {
        _isOpen = true;
        PlayOpenAnimation();
    }

    void PlayOpenAnimation()
    {
        gameObject.GetComponent<Animator>().SetTrigger("OpenPortal");
    }
}
