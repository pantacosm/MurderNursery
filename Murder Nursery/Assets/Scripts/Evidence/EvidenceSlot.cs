using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EvidenceSlot : MonoBehaviour 
{
    public bool slotFilled = false; //Checks if the evidence slot is currently filled
    public Image evidenceImage = null; //The evidence image stored in the slot
    public string evidenceText = null; //The evidence text stored in the slot
    public GameObject pinboardManager;
    public int evidenceID;
    public GameObject prefab;
    public List<GameObject> threads = new List<GameObject>();

    //private bool clearing = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearEvidence()
    {
        this.GetComponent<Image>().sprite = null;
        slotFilled = false;
        this.gameObject.SetActive(false);
        ReturnEvidence();
    }

    public void ReturnEvidence()
    {
        foreach(EvidenceClass evidence in pinboardManager.GetComponent<PinboardManager>().evidencePieces)
        {
            if(evidence.evidenceID == evidenceID)
            {
                print("Calling");
                Destroy(prefab);
                pinboardManager.GetComponent<PinboardManager>().UpdateEvidenceImages(evidence);
            }
            
        }
        if (pinboardManager.GetComponent<PinboardManager>().threadedEvidence.Count >= 1)
        {
            foreach (string evidence in pinboardManager.GetComponent<PinboardManager>().threadedEvidence.ToList())
            {
                if (evidenceText == evidence)
                {
                    pinboardManager.GetComponent<PinboardManager>().threadedEvidence.Remove(evidence);
                    foreach (GameObject thread in threads)
                    {
                        Destroy(thread);
                    }
                }
            }
        }
    }
}
