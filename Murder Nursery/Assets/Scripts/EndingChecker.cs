using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingChecker : MonoBehaviour //THIS SCRIPT WILL BE REWORKED SOON 
{
    public GameObject conclusionManager; //Stores the game manager
    public GameObject endingText; //Stores the ending method 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "DetectiveDrew")
        {
            endingText.SetActive(true);
            conclusionManager.GetComponent<Conclusion>().endingReady = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "DetectiveDrew")
        {
            endingText.SetActive(false);
            conclusionManager.GetComponent<Conclusion>().endingReady = false;
        }
    }
}
