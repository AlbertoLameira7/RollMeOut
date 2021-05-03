using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    [SerializeField] private float _coolDownTime = 2f;

    void Awake()
    {
        StartCoroutine(StartSpike());
    }

    IEnumerator StartSpike()
    {
        yield return new WaitForSeconds(_coolDownTime);

        gameObject.GetComponent<Animator>().SetTrigger("Activate");

        StartCoroutine(StartSpike());
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collider!");

        if (other.CompareTag("Ball"))
        {
            PlayerRespawn.Respawn();
        }
    }
}
