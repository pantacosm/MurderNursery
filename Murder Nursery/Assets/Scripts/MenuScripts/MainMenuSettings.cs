using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenuSettings : MonoBehaviour
{
    public static MainMenuSettings settingsInstance;

    public AudioSource sfxManager;
    public AudioClip selectChoice;
    public AudioMixer musicMixer;
    public AudioMixer sfxMixer;

    public GameObject menuObject;
    public GameObject optionsMenu;
    public GameObject graphicsMenu;
    public GameObject resMenu;
    public GameObject audioMenu;
    public GameObject controlsUI;

    DialogueManager DM;

    [HideInInspector]
    public bool menuOpen;

    private void Start()
    {
        DM = FindObjectOfType<DialogueManager>();

    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape) && SceneManager.GetActiveScene().name == "MainScene")
        {
            if(!DM.dialogueZone.activeInHierarchy)
            {
                ToggleMenu();
            }
        }
    }

    public void SetVolume(float sliderValue)
    {
        musicMixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
    }

    public void SetSFXVolume(float sliderValue)
    {
        sfxMixer.SetFloat("SFXVolume", Mathf.Log10(sliderValue) * 20);
    }

    // Called as an OnClick() Event
    public void SetQuality()
    {
        ChangeQualityLevel();
        sfxManager.PlayOneShot(selectChoice, 0.4f);
    }

    // Called as an OnClick() Event
    public void SetResolution()
    {
        ChangeResolution();
        sfxManager.PlayOneShot(selectChoice, 0.4f);
    }

    // switch case selected based on selected objects name
    void ChangeQualityLevel()
    {
        string quality =  UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        switch (quality)
        {
            case "Low":
                QualitySettings.SetQualityLevel(0);
                break;
            case "Medium":
                QualitySettings.SetQualityLevel(1);
                break;
                
            case "High":
                QualitySettings.SetQualityLevel(2);
                break;
                
            case "Ultra":
                QualitySettings.SetQualityLevel(3);
                break;
        }
    }

    // switch case selected based on selected objects name
    void ChangeResolution()
    {
        string index = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        switch (index)
        {
            case "0":
                Screen.SetResolution(1152, 648, true);
                break;
            case "1":
                Screen.SetResolution(1280, 720, true);
                break;
            case "2":
                Screen.SetResolution(1360, 768, true);
                break;
            case "3":
                Screen.SetResolution(1920, 1080, true);
                break;
            case "4":
                Screen.SetResolution(2560, 1440, true);
                break;
        }
    }

    // Toggles menu during gameplay (Escape key / Resume Game Button)
    public void ToggleMenu()
    {
        if(menuOpen = !menuOpen)
        {
            menuObject.SetActive(true);
            menuOpen = true;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            menuObject.SetActive(false);
            menuOpen = false;
            Cursor.visible = false;
        }

        if(optionsMenu.activeInHierarchy)
        {
            optionsMenu.SetActive(false);
        }

        if(graphicsMenu.activeInHierarchy)
        {
            graphicsMenu.SetActive(false);
        }

        if(resMenu.activeInHierarchy)
        {
            resMenu.SetActive(false);
        }

        if(audioMenu.activeInHierarchy)
        {
            audioMenu.SetActive(false);
        }

        if(controlsUI.activeInHierarchy)
        {
            controlsUI.SetActive(false);
        }
    }

}
