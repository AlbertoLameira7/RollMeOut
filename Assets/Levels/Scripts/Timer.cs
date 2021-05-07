using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private Text _timer;
    private float seconds = 0.0f;
    private float minutes = 0.0f;
    private bool _count;

    void Awake()
    {
        _timer = GameObject.Find("Time").GetComponent<Text>();
        _count = false;
        StartCoroutine(WaitForSeconds(0.6f));
    }

    void OnEnable()
    {
        ExitController.SaveTimer += StopAndSaveTime;
    }

    void Update()
    {
        if (_count)
        {
            seconds += Time.deltaTime;
            if (seconds > 60)
            {
                minutes += 1;
                seconds = 0;
            }
        }

        _timer.text = minutes + ":" + seconds.ToString("F2");
    }

    IEnumerator WaitForSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        _count = true;
    }

    void StopAndSaveTime()
    {
        _count = false;
        PlayerPrefs.SetFloat("Level" + SceneManager.GetActiveScene().buildIndex + "_seconds", seconds);
        PlayerPrefs.SetFloat("Level" + SceneManager.GetActiveScene().buildIndex + "_minutes", minutes);
    }
}
