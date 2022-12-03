using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThreadButtons : MonoBehaviour
{
    public GameObject threadManager;
    public GameObject firstObject;
    public GameObject secondObject;
    public Button firstButton;
    public Button secondButton;
    public void SetThreadPosition()
    {
         if (threadManager.GetComponent<ThreadManager>().firstThreadItem != null)
        {
            threadManager.GetComponent<ThreadManager>().secondThreadItem = this.gameObject;
        }
        if (threadManager.GetComponent<ThreadManager>().firstThreadItem == null)
        {
            if (this.gameObject.name == "Likes" || this.gameObject.name == "Dislikes" || this.gameObject.name == "Events")
            {
                threadManager.GetComponent<ThreadManager>().firstThreadItem = this.gameObject;
            }
            
        }
    }

    
}
