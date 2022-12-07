using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StartGame : MonoBehaviour
{
    public Image blackFade;
    int timeToFade = 1;
    public AudioSource cam;
    public AudioClip selectChoice;
    public void Begin()
    {
        blackFade.gameObject.SetActive(true);
        cam.PlayOneShot(selectChoice, 0.4f);
        StartCoroutine(FadeToBlack());
        
        
    }

    public IEnumerator FadeToBlack()
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
}
