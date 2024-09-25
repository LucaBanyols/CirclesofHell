using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageOutline : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PlayerInteraction"))
        {
          this.GetComponent<OutlineScript>().enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerInteraction"))
        {
          this.GetComponent<OutlineScript>().enabled = false;
        }
    }
}
