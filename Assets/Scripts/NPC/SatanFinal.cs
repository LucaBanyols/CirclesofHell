using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SatanFinal : MonoBehaviour
{
    public GameObject inttext, Dialog, dialogImage;
    public GameObject choiceCanvas;

    public TMP_Text dialogText;
    public Sprite speakerImage;
    public AudioSource talk;
    public List<string> speakerTalk = new List<string>();

    public bool interactable;

    private int currentText = 0;
    private bool choiceShow;

    [SerializeField]
    private BoolSO lustSO;
    [SerializeField]
    private BoolSO gluttonySO;
    [SerializeField]
    private BoolSO greedSO;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerInteraction"))
        {
            inttext.SetActive(true);
            interactable = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerInteraction"))
        {
            inttext.SetActive(false);
            interactable = false;
            Dialog.SetActive(false);
            currentText = 0;
            choiceShow = false;
        }
    }

    void Update()
    {
        if(interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (currentText < speakerTalk.Count)
                {
                    dialogText.text = speakerTalk[currentText];
                    dialogImage.GetComponent<Image>().sprite = speakerImage;
                    //talk.Play();
                    Dialog.SetActive(true);
                    currentText += 1;
                } else {
                    choiceCanvas.SetActive(true);
                    choiceShow = true;
                }
            }
        }
        if (choiceShow == true)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
    }

    public void Betray()
    {
        SceneManager.LoadScene("EndTreachery");
    }

    public void DoNotBetray()
    {
        if (greedSO.Value == true)
        {
            SceneManager.LoadScene("EndGreed");
        }
        else if (gluttonySO.Value == true)
        {
            SceneManager.LoadScene("EndGluttony");
        }
        else if (lustSO.Value == true)
        {
            SceneManager.LoadScene("EndLust");
        }
        else
        {
            SceneManager.LoadScene("EndLimbo");
        }
    }
}