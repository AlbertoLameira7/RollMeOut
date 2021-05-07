using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource _audio;

    void Awake()
    {
        _audio = _audio = gameObject.GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        KeyController.KeyPickedUp += PlayPickUpSound;
    }

    void OnDisable()
    {
        KeyController.KeyPickedUp -= PlayPickUpSound;
    }

    void PlayPickUpSound()
    {
        _audio.Play();
    }
}
