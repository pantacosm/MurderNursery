using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingActivation : MonoBehaviour
{
    public GameObject filter;
    private bool filterOn;
    // Start is called before the first frame update
    void Start()
    {
        filterOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            filterOn = !filterOn;
            filter.GetComponent<PostProcessLayer>().enabled = filterOn;
        }
    }
}