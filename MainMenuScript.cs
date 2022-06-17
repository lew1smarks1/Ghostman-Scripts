using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField]
    private GameObject mainMenuButtons;

    [SerializeField]
    private GameObject settingsMenu;

    [SerializeField]
    private GameObject creditsMenu;

    [SerializeField]
    private GameObject stageSelectButtons;

    public GameObject End1Objects;
    public GameObject End2Objects;
    public GameObject End3Objects;

    //initialize playerprefs
    void Start()
    {
        if (!PlayerPrefs.HasKey("LoveFound"))
        {
            PlayerPrefs.SetFloat("LoveFound", 0);
        }

        if (!PlayerPrefs.HasKey("End1"))
        {
            PlayerPrefs.SetFloat("End1", 0);
        }
        if (PlayerPrefs.GetFloat("End1") == 1)
        {
            LoadEnd1();
        }


        if (!PlayerPrefs.HasKey("End2"))
        {
            PlayerPrefs.SetFloat("End2", 0);
        }
        if (PlayerPrefs.GetFloat("End2") == 1)
        {
            LoadEnd2();
        }

        if (!PlayerPrefs.HasKey("End3"))
        {
            PlayerPrefs.SetFloat("End3", 0);
        }
        if(PlayerPrefs.GetFloat("End3")==1)
        {
            LoadEnd3();
        }
    }

    private void LoadEnd1()
    {
        End1Objects.SetActive(true);
        //show ghostman <3 human in top right
    }

    private void LoadEnd2()
    {
        End2Objects.SetActive(true);
        // show Cat <3 Ghostman in bottom right
    }

    private void LoadEnd3()
    {
        End3Objects.SetActive(true);
        //Add 5 humans to the start screen
    }


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        settingsMenu.SetActive(false);
    }

    public void NewGame()//stageselect buttons on
    {
        audioSource.Play();
        mainMenuButtons.SetActive(false);
        stageSelectButtons.SetActive(true);
    }

    public void StageSelectOff()//stageselect buttons off
    {
        audioSource.Play();
        stageSelectButtons.SetActive(false);
        mainMenuButtons.SetActive(true);

    }

    public void Settings()//activates settings menu while disabling the other options
    {
        audioSource.Play();
        mainMenuButtons.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void SettingsOff()//returns from settings menu to the main menu
    {
        audioSource.Play();
        mainMenuButtons.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void QuitGame()//quit game button
    {
        audioSource.Play();
        Application.Quit();
    }

    public void CreditsOn()//turn credits on
    {
        audioSource.Play();
        mainMenuButtons.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void CreditsOff()//turn credits off
    {
        audioSource.Play();
        creditsMenu.SetActive(false);
        mainMenuButtons.SetActive(true);
    }

    public void StageSelect(Button button)//selects the stage and loads the scene
    {
        audioSource.Play();
        SceneManager.LoadScene("Stage " + button.name);
    }

    public void ResetMemory()//resets playerprefs
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
