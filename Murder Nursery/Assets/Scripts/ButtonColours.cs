using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonColours : MonoBehaviour
{
    public GameObject button1;
    public GameObject button2; 
    public GameObject button3;
    public GameObject manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseEnter()
    {
        print("Calling");
        if(this.gameObject == button1)
        {
            manager.GetComponent<DialogueManager>().pos = 0;
        }
        if(this.gameObject == button2)
        {
            manager.GetComponent<DialogueManager>().pos = 1;
        }
        if(this.gameObject == button3)
        {
            manager.GetComponent<DialogueManager>().pos = 2;
        }
    }
}
