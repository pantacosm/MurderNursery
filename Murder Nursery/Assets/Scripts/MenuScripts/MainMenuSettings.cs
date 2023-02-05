using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSettings : MonoBehaviour
{
    string quality;
    string index;

    public AudioSource cam;
    public AudioClip selectChoice;

    public GameObject menuObject;
    public GameObject settingsMenu;

    [HideInInspector]
    public bool menuOpen;

    // Start is called before the first frame update
    void Start()
    {
        //quality = "High";
        //index = "3";
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape) && SceneManager.GetActiveScene().name == "MainScene")
        {
            ToggleMenu();
        }
    }

    // Called as an OnClick() Event
    public void SetQuality()
    {
        ChangeQualityLevel();
        cam.PlayOneShot(selectChoice, 0.4f);
    }

    // Called as an OnClick() Event
    public void SetResolution()
    {
        ChangeResolution();
        cam.PlayOneShot(selectChoice, 0.4f);
    }

    // switch case selected based on selected objects name
    void ChangeQualityLevel()
    {
        quality =  UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

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
        index = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

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

    // Toggles menu during gameplay (Escape key)
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

        if(settingsMenu.activeInHierarchy)
        {
            settingsMenu.SetActive(false);
        }
    }

}
