using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour
{
    public GameObject nextMusic;

    void OnTriggerEnter()
    {
        Destroy(this.gameObject);
        nextMusic.SetActive(true);
    }
}
