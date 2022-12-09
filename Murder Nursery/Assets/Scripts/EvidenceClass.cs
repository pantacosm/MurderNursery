using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EvidenceClass : MonoBehaviour
{
    public string evidenceText;
    public bool evidenceFound = false;
    public int evidenceID;
    public GameObject pinBoardManager;
    public GameObject evidenceList;
    public GameObject evidenceImage;
   
    // Start is called before the first frame update
    public void Start()
    {
        evidenceFound = false;
    }
    public void DiscoverEvidence()
    {
        
    }
}
