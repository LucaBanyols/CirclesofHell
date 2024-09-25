using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPlayScene : MonoBehaviour
{
    [SerializeField]
    private StringSO saveSceneSO;

    void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void startGame(string firstGameScene)
    {
        SceneManager.LoadScene(firstGameScene);
    }

    public void resumeGame()
    {
        SceneManager.LoadScene(saveSceneSO.Value);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
