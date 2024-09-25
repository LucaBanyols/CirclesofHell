using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private GameObject playerBody;
    private ManagePlayer playerScript;

    void Start()
    {
        playerBody = GameObject.Find("PlayerBody");
        playerScript = playerBody.GetComponent<ManagePlayer>();
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
        playerScript.PickupFood();
    }
}
