using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropperObstacle2 : MonoBehaviour
{
    public GameObject playerBody;
    public int removePourcentageChance;
    public int minSpeed;
    public int maxSpeed;
    public float x_Axis;
    public float z_Axis;

    private ManagePlayer playerScript;
    private float randomY;
    private float randomSpeed;
    private int randomIsPrint;
    private int randomPosNeg;

    void Start()
    {
        playerScript = playerBody.GetComponent<ManagePlayer>();
        randomY = Random.Range(0, 360);
        this.transform.rotation = Quaternion.Euler(x_Axis, randomY, z_Axis);
        randomSpeed = Random.Range(minSpeed, maxSpeed);
        randomIsPrint = Random.Range(1, 100);
        randomPosNeg = Random.Range(0, 2);
        if (randomPosNeg == 1)
        {
            randomSpeed = -1 * randomSpeed;
        }
        if (randomIsPrint <= removePourcentageChance)
        {
            this.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        this.transform.RotateAround(this.transform.position, Vector3.up, Time.deltaTime * randomSpeed);
    }

    void OnTriggerEnter()
    {
        playerScript.TakeDamage(10f);
    }
}
