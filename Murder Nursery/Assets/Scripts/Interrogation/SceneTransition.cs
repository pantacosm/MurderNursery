using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    public Image blackFade;
    public bool toBlack;
    public bool screenBlack;
    private GameObject manager;
    public GameObject mainCamera;
    public GameObject interrogationCam;
    public GameObject currentCam;
    public bool interrogationActive;
    float currentCountdownValue;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");
        interrogationActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            ChangeToInterrogation();            
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            ChangeToMainArea();
        }

    }

    private void ChangeCam(GameObject currentCam, GameObject newCam)
    {
        currentCam.SetActive(false);
        newCam.SetActive(true);
        currentCam = newCam;
    }

    private void ChangeToInterrogation()
    {

        StartCoroutine(BlackTransitionToInterrogation(mainCamera, interrogationCam));
        StartCoroutine(WaitForSeconds());             
    }
    private void ChangeToMainArea()
    {
        StartCoroutine(BlackTransitionToInterrogation(interrogationCam, mainCamera));
        StartCoroutine(WaitForSeconds());
    }

    public IEnumerator BlackTransitionToInterrogation(GameObject currentCam, GameObject desiredCam, bool transitionToBlack = true, int timeToFade = 1)
    {
        Color screenColour = blackFade.color;
        float fadeProgress;
        if (transitionToBlack)
        {           
            while (blackFade.color.a < 1)
            {
                fadeProgress = screenColour.a  + (timeToFade * Time.deltaTime);
                screenColour = new Color(screenColour.r, screenColour.g, screenColour.b, fadeProgress);
                blackFade.color = screenColour;
                if(fadeProgress > 0.95f)
                {
                    ChangeCam(currentCam, desiredCam);
                }
                
                yield return null;
            }
        }
        else
        {
            while(blackFade.color.a > 0)
            {
                fadeProgress = screenColour.a - (timeToFade * Time.deltaTime);
                screenColour = new Color(screenColour.r, screenColour.g, screenColour.b, fadeProgress);
                blackFade.color = screenColour;
                yield return null;
            }
        }
    }

    public IEnumerator WaitForSeconds(float countdownValue = 2)
    {
        currentCountdownValue = countdownValue;
        while (currentCountdownValue > 0)
        {
            yield return new WaitForSeconds(1);
            currentCountdownValue--;
        }
        StartCoroutine(BlackTransitionToInterrogation(mainCamera, interrogationCam, false));
        
    }

}
