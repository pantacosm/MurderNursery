using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public GameObject responseText1;
    public GameObject responseText2;
    public GameObject responseText3;
    public GameObject statementText;
    public GameObject responseBox1;
    public GameObject responseBox2; 
    public GameObject responseBox3; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeactivateChoices()
    {
        responseBox1.gameObject.SetActive(false);
        responseBox2.gameObject.SetActive(false);
        responseBox3.gameObject.SetActive(false);
    }
    public void LoadNPCStatement(string statement) //Loads NPC dialogue into main box
    {
        statementText.GetComponent<TextMeshProUGUI>().text = statement;
    }
    public void LoadResponses(string firstResponse) //Loads in a single response, used when we only need to leave a convo 
    {
        responseBox1.gameObject.SetActive(true);
        responseText1.GetComponent<TextMeshProUGUI>().text = firstResponse;
        responseBox2.gameObject.SetActive(false);
        responseBox3.gameObject.SetActive(false);
    }
    public void LoadResponses(string firstResponse, string secondResponse) //Loads in two responses, e.g. in the proposed truth or dare scenario
    {
        responseBox1.gameObject.SetActive(true);
        responseBox2.gameObject.SetActive(true);
        responseText1.GetComponent<TextMeshProUGUI>().text = firstResponse;
        responseText2.GetComponent<TextMeshProUGUI>().text = secondResponse;
        responseBox3.gameObject.SetActive(false);
    }
    public void LoadResponses(string firstResponse, string secondResponse, string thirdResponse) //Loads in all three responses, most commonly used
    {
        responseBox1.gameObject.SetActive(true);
        responseBox2.gameObject.SetActive(true);
        responseBox3.gameObject.SetActive(true);
        responseText1.GetComponent<TextMeshProUGUI>().text = firstResponse;
        responseText2.GetComponent<TextMeshProUGUI>().text = secondResponse;
        responseText3.GetComponent<TextMeshProUGUI>().text = thirdResponse;
    }

    
}
