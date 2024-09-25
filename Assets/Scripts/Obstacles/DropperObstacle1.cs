using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropperObstacle1 : MonoBehaviour
{
    public GameObject playerBody;
    public float ySpeed;

    private ManagePlayer playerScript;

    void Start()
    {
        playerScript = playerBody.GetComponent<ManagePlayer>();
    }

    void Update()
    {
        this.transform.RotateAround(this.transform.position, Vector3.up, Time.deltaTime * ySpeed);
    }

    void OnTriggerEnter()
    {
        playerScript.TakeDamage(10f);
    }
}
