﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Threat : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("Ball"))
        {
            PlayerRespawn.Respawn();
        }
    }
}
