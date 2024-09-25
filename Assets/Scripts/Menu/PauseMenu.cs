using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    private bool isPause;
    private float time;

    [SerializeField]
    private StringSO saveSceneSO;

    void Start()
    {
        isPause = false;
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (isPause == true)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        isPause = true;
    }

    public void Resume()
    {
        isPause = false;
        pauseMenu.SetActive(false);
    }

    public void Settings()
    {
        Debug.Log("Settings");
    }

    public void ReturnToMainMenu(string scene)
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        saveSceneSO.Value = SceneManager.GetActiveScene().name;
        Time.timeScale = 1f;
        Cursor.visible = true;
        SceneManager.LoadScene(scene);
    }

    public void Quit()
    {
        saveSceneSO.Value = SceneManager.GetActiveScene().name;
        Time.timeScale = 1f;
        Debug.Log("Quit");
        Application.Quit();
    }

    public void PlayAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
