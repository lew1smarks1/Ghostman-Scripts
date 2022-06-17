using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GameObject.Find("ButtonSound").GetComponent<AudioSource>();
    }

    public void Restart()//Restart the next level
    {
        if(!Winner.winGame && !PauseScreenScript.isPaused)
        audioSource.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
