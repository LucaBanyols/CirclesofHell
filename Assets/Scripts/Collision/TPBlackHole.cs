using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TPBlackHole : MonoBehaviour
{
    public string nextScene;

    [SerializeField]
    private IntSO playerCoinsSO;
    [SerializeField]
    private IntSO playerCoinsWinSO;

    void OnTriggerEnter()
    {
        playerCoinsSO.Value = playerCoinsSO.Value + playerCoinsWinSO.Value;
        playerCoinsWinSO.Value = 0;
        SceneManager.LoadScene(nextScene);
    }
}
