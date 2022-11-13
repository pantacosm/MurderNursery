using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interrogation : MonoBehaviour
{
    public GameObject manager;
    public GameObject interrogationPanel;
    public bool interrogationUnderway;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");
    }

    // Update is called once per frame
    void Update()
    {
        interrogationUnderway = manager.GetComponent<SceneTransition>().interrogationActive;

        
    }
}
