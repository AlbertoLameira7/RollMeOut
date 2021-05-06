using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    void Awake()
    {
        DisplayTimes();
    }

    void DisplayTimes()
    {
        float _minutes = 0f;
        float _seconds = 0f;

        for (int i = 2; i < SceneManager.sceneCountInBuildSettings - 1; i++)
        {
            GameObject.Find("Level" + (i -1)).GetComponent<Text>().text = "Level" + (i -1) + " - " + PlayerPrefs.GetFloat("Level" + i + "_minutes") + ":" + PlayerPrefs.GetFloat("Level" + i + "_seconds").ToString("F2");
            _minutes += PlayerPrefs.GetFloat("Level" + i + "_minutes");
            _seconds += PlayerPrefs.GetFloat("Level" + i + "_seconds");
        }

        _minutes += Mathf.Round(_seconds / 60f);
        _seconds = _seconds % 60;

        GameObject.Find("Total").GetComponent<Text>().text = "Total: " + _minutes + ":" + _seconds.ToString("F2");
    }
}
