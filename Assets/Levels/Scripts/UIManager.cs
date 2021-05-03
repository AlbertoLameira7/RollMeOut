using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Animator animator;
    public float transitionTime = 1f;

    public void PlayGame()
    {
        StartCoroutine(FadeManager.instance.LoadLevel(1));
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
