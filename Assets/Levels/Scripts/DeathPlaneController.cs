using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeathPlaneController : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            PlayerRespawn.Respawn();
        }
    }
}
