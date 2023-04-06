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

    public AudioSource sfxAudio;
    public AudioClip sfxAudioClip;

    private GameObject evidenceItem;
    private bool comparingFingerprint;

    public void CloseFingerprintUI()
    {

        fingerprintUI.SetActive(false);
        evidenceItem.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CompareFingerprints()
    {
        if(fingerprintFound.name == gameObject.name && !comparingFingerprint) // correct match
        {
            evidenceItem = EvidenceItem.evidenceItem.gameObject;
            comparingFingerprint = true;
            particleLight.GetComponent<ParticleSystem>().Play();
            StartCoroutine(StopLightParticle(3f));
        }
        else if(!comparingFingerprint)
        {
            comparingFingerprint = true;
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
            comparingFingerprint = false;
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
            sfxAudio.PlayOneShot(sfxAudioClip, 0.2f);
            StartCoroutine(StopStarParticle(1f));
            correctMatchText.SetActive(true);
            comparingFingerprint = false;
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
            evidenceItem.GetComponent<EvidenceItem>().inspectingItem = false;
            InventoryManager.inventory.AddItem(evidenceItem.GetComponent<EvidenceItem>().item);
            InventoryManager.inventory.MG.GetComponent<MagnifyingGlass>().gameObject.SetActive(true);
            InventoryManager.inventory.MG.GetComponent<MagnifyingGlass>().magnifyingBlur.SetActive(true);
            particleStar.GetComponent<ParticleSystem>().Stop();
            correctMatchText.SetActive(false);
            CloseFingerprintUI();
        }
    }
}
