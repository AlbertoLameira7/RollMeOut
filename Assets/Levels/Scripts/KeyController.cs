using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KeyController : MonoBehaviour
{
    public static Action KeyPickedUp;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            KeyPickedUp();
            Destroy(gameObject);
        }
    }
}
