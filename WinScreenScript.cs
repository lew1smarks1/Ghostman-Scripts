using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenScript : MonoBehaviour
{

    //opens up the win game menu when the player touches the flag

    private AudioSource audioSource;
    [SerializeField] private GameObject winScreen;

    private void Awake()
    {
        audioSource = GameObject.Find("ButtonSound").GetComponent<AudioSource>();
    }
    
    private void Update()
    {
        if (Winner.winGame)
        {
            winScreen.SetActive(true);
            PauseScreenScript.canPause = false;
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().buildIndex.ToString(), 1);
        }
    }

    public void Continue()//continue to the next level
    {
        audioSource.Play();
        Winner.winGame = false;
        PauseScreenScript.canPause = true;
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void MainMenu()//loads the main menu
    {
        audioSource.Play();
        Winner.winGame = false;
        PauseScreenScript.canPause = true;
        SceneManager.LoadScene("MainMenu");
    }
}
