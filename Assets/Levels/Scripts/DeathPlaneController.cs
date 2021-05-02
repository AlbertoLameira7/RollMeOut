using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeathPlaneController : MonoBehaviour
{
    public static Action Respawn;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Respawn();
        }
    }
}
