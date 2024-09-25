using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ManagePlayer : MonoBehaviour
{
    public Slider healthSlider;
    public GameObject playerBody;
    public GameObject playerArmature;
    public float maxHeightFromDamage = 3f;
    public float abyssDamage = 0.1f;
    public TMP_Text numberCoinText;

    [SerializeField]
    private FloatSO playerHealthSO;

    [SerializeField]
    private IntSO playerCoinsSO;
    [SerializeField]
    private IntSO playerCoinsWinSO;
    [SerializeField]
    private BoolSO lustSO;
    [SerializeField]
    private BoolSO gluttonySO;
    [SerializeField]
    private BoolSO greedSO;


    Break_Ghost breakGhostScript;
    private float maxY;

    void Start()
    {
        breakGhostScript = playerBody.GetComponent<Break_Ghost>();
        maxY = playerArmature.transform.position.y + maxHeightFromDamage;
        numberCoinText.text = playerCoinsSO.Value + playerCoinsWinSO.Value + "";
        healthSlider.value = playerHealthSO.Value;
    }

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.T))
        // {
        //     TakeDamage(0.5f);
        // }
        
        // if (Input.GetKeyDown(KeyCode.R))
        // {
        //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // }
        AbyssDamage();
    }

    public void TakeDamage(float damage)
    {
        playerHealthSO.Value -= damage;
        healthSlider.value = playerHealthSO.Value;

        if (playerHealthSO.Value <= 0f)
        {
            breakGhostScript.break_Ghost();
            StartCoroutine(RespawnCoroutine());
        }
    }

    IEnumerator RespawnCoroutine()
    {
        yield return new WaitForSeconds(2);
        Respawn();
    }

    public void AbyssDamage()
    {
        if (maxY >= playerArmature.transform.position.y + maxHeightFromDamage)
        {
            maxY = playerArmature.transform.position.y + maxHeightFromDamage;
        }

        if (playerArmature.transform.position.y >= maxY)
        {
            TakeDamage(abyssDamage);
            maxY = playerArmature.transform.position.y + maxHeightFromDamage;
        }
    }

    public void Lust()
    {
        lustSO.Value = true;
    }

    public void PickupFood()
    {
        playerHealthSO.Value += 1f;
        if (playerHealthSO.Value >= 10f)
        {
            playerHealthSO.Value = 10f;
        }
        healthSlider.value = playerHealthSO.Value;
        gluttonySO.Value = true;
    }

    public void AddCoin()
    {
        playerCoinsWinSO.Value++;
        numberCoinText.text = playerCoinsSO.Value + playerCoinsWinSO.Value + "";
        greedSO.Value = true;
    }

    public void Respawn()
    {
        playerCoinsWinSO.Value = 0;
        playerHealthSO.Value = 10f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
