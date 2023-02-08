using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StartGame : MonoBehaviour
{
    public Image blackFade; //Image used as a fader for transition to main game 
    int timeToFade = 1; //Time to fade to black
    public AudioSource cam; //Audio source for start menu
    public AudioClip selectChoice; //Sound used for choosing an option
    public GameObject settingsMenu; //UI element for settings menu
    public GameObject controlsUI; // UI image of controls

    public void Begin() //Used when the player starts the game
    {
        blackFade.gameObject.SetActive(true); 
        cam.PlayOneShot(selectChoice, 0.4f); //Plays relevant sound 
        StartCoroutine(FadeToBlack()); //Begins black fade
        
        if(settingsMenu.activeInHierarchy)
        {
            CloseSettings(); //Closes settings menu
        }
        
    }

    public IEnumerator FadeToBlack() //Coroutine similiar to scene transition one //Used to fade the screen to black
    {
        Color screenColour = blackFade.color;
        float fadeProgress;
        
            while (blackFade.color.a < 1)
            {
                fadeProgress = screenColour.a + (timeToFade * Time.deltaTime);
                screenColour = new Color(screenColour.r, screenColour.g, screenColour.b, fadeProgress);
                blackFade.color = screenColour;
                if(fadeProgress > 0.9999f)
            {
                SceneManager.LoadScene("MainScene");
                Cursor.visible = false;
            }

                yield return null;
            }
        
        
    }

    public void Settings() //Opens settings menu
    {
        settingsMenu.SetActive(true);
        cam.PlayOneShot(selectChoice, 0.4f);

        if(controlsUI.activeInHierarchy)
        {
            controlsUI.SetActive(false);
        }
    }

    public void CloseSettings() //Closes settings menu
    {
        settingsMenu.SetActive(false);
        cam.PlayOneShot(selectChoice, 0.4f);
    }

    public void QuitGame() //Quits the game 
    {
        cam.PlayOneShot(selectChoice, 0.4f);
        if(UnityEngine.Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }
}
