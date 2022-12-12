using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingChecker : MonoBehaviour
{
    public GameObject conclusionManager;
    public GameObject endingText;

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
