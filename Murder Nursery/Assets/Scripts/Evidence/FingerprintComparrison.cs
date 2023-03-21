using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerprintComparrison : MonoBehaviour
{
    [SerializeField]
    GameObject fingerprintUI;

    [SerializeField]
    GameObject fingerprintFound;

    [SerializeField]
    GameObject incorrectMatchText;

    [SerializeField]
    GameObject correctMatchText;

    [SerializeField]
    GameObject particleLight;

    [SerializeField]
    GameObject particleStar;

    GameObject evidenceItem;

    public void CloseFingerprintUI()
    {

        fingerprintUI.SetActive(false);
        evidenceItem = GameObject.FindGameObjectWithTag("Evidence Item");
        evidenceItem.GetComponent<EvidenceItem>().inspectingItem = false;
        evidenceItem.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CompareFingerprints()
    {
        if(fingerprintFound.name == gameObject.name)
        {
            
            particleLight.GetComponent<ParticleSystem>().Play();
            StartCoroutine(StopLightParticle(3f));
        }
        else
        {
            incorrectMatchText.SetActive(true);
            StartCoroutine(HideText(2f));
        }
    }

    IEnumerator HideText(float duration)
    {
        float time = 0;
        while(time < duration)
        {
            time += Time.deltaTime;
            yield return null;
        }

        if(time >= duration)
        {
            incorrectMatchText.SetActive(false);
        }
    }

    IEnumerator StopLightParticle(float duration)
    {
        float time = 0;
        while(time < duration)
        {
            time += Time.deltaTime;
            yield return null;
        }

        if(time >= duration)
        {
            particleLight.GetComponent<ParticleSystem>().Stop();
            particleStar.GetComponent<ParticleSystem>().Play();
            StartCoroutine(StopStarParticle(1f));
            correctMatchText.SetActive(true);
        }
    }

    IEnumerator StopStarParticle(float duration)
    {
        float time = 0;
        while(time < duration)
        {
            time += Time.deltaTime;
            yield return null;
        }

        if(time >= duration)
        {
            particleStar.GetComponent<ParticleSystem>().Stop();
            correctMatchText.SetActive(false);
            CloseFingerprintUI();
            InventoryManager.inventory.MG.GetComponent<MagnifyingGlass>().gameObject.SetActive(true);
            InventoryManager.inventory.MG.GetComponent<MagnifyingGlass>().magnifyingBlur.SetActive(true);
        }
    }
}
