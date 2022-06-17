using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winner : MonoBehaviour
{
    public static bool winGame = false;
    private AudioSource winSound;
    private bool hasPlayed;

    private void Start()
    {
        winSound = GameObject.Find("FlagSound").GetComponent<AudioSource>();
    }
    private void Awake()
    {
        hasPlayed = false;
        winGame = false;
    }
    //allows the wingame state when the player touches the flag
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Flag" && !hasPlayed)
        {
            winGame = true;
            winSound.Play();
            hasPlayed = true;
            //do win game stuff
        }
    }
}
