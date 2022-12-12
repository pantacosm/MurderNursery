using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Conclusion : MonoBehaviour
{
    public GameObject mainScene;
    public GameObject suspectSelectionCam;
    public GameObject goodEndingCam;
    public GameObject badEndingCam;
    public GameObject trueEndingCam;
    public GameObject manager;
    public Image blackFade;
    public bool eddieChosen = false;
    public bool chaseChosen = false;
    public bool scarletChosen = false;
    public bool juiceboxChosen = false;
    public bool graceChosen = false;
    public GameObject eddie;
    public GameObject chase;
    public GameObject juicebox;
    public GameObject grace;
    public GameObject scarlet;
    public GameObject trueEndingText;
    public GameObject goodEndingText;
    public GameObject badEndingText;
    public GameObject scarletEnd;
    public GameObject eddieEnd;
    public GameObject juiceBoxEnd;
    public GameObject drewEnd;
    public GameObject chaseEnd;
    public GameObject scarletMain;
    public GameObject eddieMain;
    public GameObject juiceBoxMain;
    public GameObject drewMain;
    public GameObject chaseMain;
    public GameObject tempText;
    public bool endingReady = false;
    public GameObject endingText;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C) && endingReady)
        {
            StartConclusion();
        }
    }

    public void StartConclusion()
    {
        blackFade.gameObject.SetActive(true);
        StartCoroutine(BlackTransition(mainScene, suspectSelectionCam));
        StartCoroutine(WaitThenFadeIn());
        Cursor.visible = true;
    }

    public void SuspectChosen()
    {
        if(eddieChosen)
        {
            
            blackFade.gameObject.SetActive(true);
            StartCoroutine(BlackTransition(suspectSelectionCam, badEndingCam));
            StartCoroutine(WaitThenFadeIn(eddie, true));
            eddieMain.SetActive(false);
            scarletMain.SetActive(false);
            drewMain.SetActive(false);
            chaseMain.SetActive(false);
            juiceBoxMain.SetActive(false);
            eddieEnd.SetActive(true);
            scarletEnd.SetActive(true);
            drewEnd.SetActive(true);
            juiceBoxEnd.SetActive(true);
            chaseEnd.SetActive(true);
            
        }
        if(chaseChosen)
        {
            print("Chase ending here");
            blackFade.gameObject.SetActive(true);
            StartCoroutine(BlackTransition(suspectSelectionCam, badEndingCam));
            StartCoroutine(WaitThenFadeIn(chase, true));
        }
        if(scarletChosen)
        {
            print("Scarlet ending here");
            blackFade.gameObject.SetActive(true);
            StartCoroutine(BlackTransition(suspectSelectionCam, badEndingCam));
            StartCoroutine(WaitThenFadeIn(scarlet, true));
        }
        if(juiceboxChosen)
        {
            print("Juice Box ending here");
            blackFade.gameObject.SetActive(true);
            StartCoroutine(BlackTransition(suspectSelectionCam, badEndingCam));
            StartCoroutine(WaitThenFadeIn(juicebox, true));

        }
        if(graceChosen)
        {
            print("Grace ending here");
            blackFade.gameObject.SetActive(true);
            StartCoroutine(BlackTransition(suspectSelectionCam, trueEndingCam));
            StartCoroutine(WaitThenFadeIn(grace, true));
        }

    }

    public IEnumerator BlackTransition(GameObject currentCam = null, GameObject desiredCam = null, GameObject npcTalking = null, bool startDialogue = false, bool transitionToBlack = true, float fadeSpeed = 1)
    {
        Color screenColour = blackFade.color;
        float fadeProgress;
        if (transitionToBlack)
        {
            while (blackFade.color.a < 1)
            {
                fadeProgress = screenColour.a + (fadeSpeed * Time.deltaTime);
                screenColour = new Color(screenColour.r, screenColour.g, screenColour.b, fadeProgress);
                blackFade.color = screenColour;
                if (fadeProgress > 0.95f && currentCam!=null && desiredCam!=null)
                {
                    manager.GetComponent<SceneTransition>().ChangeCam(currentCam, desiredCam);
                    
                }
                if (fadeProgress > 0.95f && manager.GetComponent<DialogueManager>().trueEndingReached)
                {
                    trueEndingText.SetActive(true);
                }
                if(fadeProgress > 0.95f && manager.GetComponent<DialogueManager>().goodEndingReached)
                {
                    goodEndingText.SetActive(true);
                }
                if(fadeProgress > 0.95f && manager.GetComponent<DialogueManager>().badEndingReached)
                {
                    badEndingText.SetActive(true);
                }

                yield return null;
            }
        }
        else
        {
            while (blackFade.color.a > 0)
            {
                fadeProgress = screenColour.a - (fadeSpeed * Time.deltaTime);
                screenColour = new Color(screenColour.r, screenColour.g, screenColour.b, fadeProgress);
                blackFade.color = screenColour;
                if (fadeProgress < 0.01f)
                {
                    blackFade.gameObject.SetActive(false);
                    if(eddieChosen)
                    {
                        tempText.SetActive(true);
                    }
                    
                    if (startDialogue)
                    {
                        manager.GetComponent<DialogueManager>().StartConversation(npcTalking.GetComponent<NPCDialogue>().dialogueTree[0], npcTalking, manager.GetComponent<DialogueManager>().currentNPCCam);
                    }
                    
                    yield return null;
                }
                yield return null;
            }
        }
    }

    public IEnumerator WaitThenFadeIn(GameObject npcTalking = null, bool startDialogue = false, float countdownValue = 2)
    {
        float currentCountdown = countdownValue;
        while (currentCountdown > 0)
        {
            yield return new WaitForSeconds(1);
            currentCountdown--;
        }
        StartCoroutine(BlackTransition(null, null, npcTalking, startDialogue, false));
    }

    public void EddieChosen()
    {
        eddieChosen = true;
        SuspectChosen();
    }

    public void ScarletChosen()
    {
        scarletChosen = true;
        SuspectChosen();
    }

    public void JuiceBoxChosen()
    {
        juiceboxChosen = true;
        SuspectChosen();
    }

    public void ChaseChosen()
    {
        chaseChosen = true;
        SuspectChosen();
    }

    public void GraceChosen()
    {
        graceChosen = true;
        SuspectChosen();
    }

   

}
