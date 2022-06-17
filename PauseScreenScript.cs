using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseScreenScript : MonoBehaviour
{
    public static bool isPaused = false;
    [SerializeField]
    private GameObject pauseMenuUI;
    private AudioSource audioSource;
    public static bool canPause = true;
    public TextMeshProUGUI stageName;
    public TextMeshProUGUI stageNamePause;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && canPause)//escape to pause the game, while paused escape to resume
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        GetStageName();
    }

    private void Awake()
    {
        audioSource = GameObject.Find("ButtonSound").GetComponent<AudioSource>();
    }
    public void Resume()//resumes the game and gets rid of the pausemenuUI
    {
        audioSource.Play();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()//pauses the game and shows the pausemenuUI
    {
        audioSource.Play();
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LoadMenu()//loads the main menu
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused=false;
        audioSource.Play();
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()//quits the game
    {
        audioSource.Play();
        Application.Quit();
    }
    
    //gets the stage name and changes it
    private void GetStageName()
    {
        if (SceneManager.GetActiveScene().buildIndex -1 == 1)
        {
            stageName.text = "1: Life Could Be a Dream";
            stageNamePause.text = "1: Life Could Be a Dream";
        }
        else if (SceneManager.GetActiveScene().buildIndex - 1 == 2)
        {
            stageName.text = "2: Out Is The New In";
            stageNamePause.text = "2: Out Is The New In";
        }
        else if (SceneManager.GetActiveScene().buildIndex - 1 == 3)
        {
            stageName.text = "3: Who?";
            stageNamePause.text = "3: Who?";
        }
        else if (SceneManager.GetActiveScene().buildIndex - 1 == 4)
        {
            stageName.text = "4: They're Fine...";
            stageNamePause.text = "4: They're Fine...";
        }
        else if (SceneManager.GetActiveScene().buildIndex - 1 == 5)
        {
            stageName.text = "5: Two Guys";
            stageNamePause.text = "5: Two Guys";
        }
        else if (SceneManager.GetActiveScene().buildIndex - 1 == 6)
        {
            stageName.text = "6: And Through And Through";
            stageNamePause.text = "6: And Through And Through";
        }
        else if (SceneManager.GetActiveScene().buildIndex - 1 == 7)
        {
            stageName.text = "7: Ghost Me Out Of Here!";
            stageNamePause.text = "7: Ghost Me Out Of Here!";
        }
        else if (SceneManager.GetActiveScene().buildIndex - 1 == 8)
        {
            stageName.text = "8: Box Boys";
            stageNamePause.text = "8: Box Boys";
        }
        else if (SceneManager.GetActiveScene().buildIndex - 1 == 9)
        {
            stageName.text = "9: Trust me";
            stageNamePause.text = "9: Trust me";
        }
        else if (SceneManager.GetActiveScene().buildIndex - 1 == 10)
        {
            stageName.text = "10: To me, To you";
            stageNamePause.text = "10: To me, To you";
        }
        else if (SceneManager.GetActiveScene().buildIndex - 1 == 11)
        {
            stageName.text = "11: Again?";
            stageNamePause.text = "11: Again?";
        }
        else if (SceneManager.GetActiveScene().buildIndex - 1 == 12)
        {
            stageName.text = "12: Death Is Only The Beginning";
            stageNamePause.text = "12: Death Is Only The Beginning";
        }
        else if (SceneManager.GetActiveScene().buildIndex - 1 == 13)
        {
            stageName.text = "13: Charge!";
            stageNamePause.text = "13: Charge!";
        }
        else if (SceneManager.GetActiveScene().buildIndex - 1 == 14)
        {
            stageName.text = "14: I Could Simply Snap My Fingers...";
            stageNamePause.text = "14: I Could Simply Snap My Fingers...";
        }


    }
}
