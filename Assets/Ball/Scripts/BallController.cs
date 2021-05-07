using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public void PlayEndLevelAnimation()
    {
        gameObject.GetComponent<Animator>().SetTrigger("EndLevel");
    }
}
