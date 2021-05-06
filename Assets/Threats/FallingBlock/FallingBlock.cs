using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FallingBlock : MonoBehaviour
{
    public static Action<GameObject> FallingBlockEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            FallingBlockEvent(gameObject);
        }
    }
}
