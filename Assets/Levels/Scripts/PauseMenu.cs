using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool _isPaused;

    void Awake()
    {
        _isPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (!_isPaused)
        {
            _isPaused = true;
            PauseGame();
            Time.timeScale = 0f;
        }
        else
        {
            _isPaused = false;
            PauseGame();
            Time.timeScale = 1f;
        }
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f; // TODO: refactor
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // TODO: refactor
        SceneManager.LoadScene(0);
    }

    void PauseGame()
    {
        gameObject.GetComponent<Canvas>().enabled = _isPaused;
    }
}
