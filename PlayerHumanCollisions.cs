using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHumanCollisions : MonoBehaviour
{
    public GameObject playerGhost;
    private AudioSource deathSound;
    public static bool hasCollided = false;
    //private AudioSource pushSound;

    private void Awake()
    {
        hasCollided = false;
    }

    private void Start()
    {
        deathSound = GameObject.Find("HumanDeathSound").GetComponent<AudioSource>();
        //pushSound = GameObject.Find("PushingSound").GetComponent<AudioSource>();
        //used to have a push sound for boxes
    }

    //if the player collides with a ghost, it turns into a ghost and destroys the ghost
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Ghost" && !hasCollided)
        {
            hasCollided = true;
            gameObject.SetActive(false);
            PlayerMovement.isHuman = false;
            playerGhost.SetActive(true);
            Destroy(collision.transform.parent.gameObject);
            deathSound.Play();
        }

    }


    /*
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Box" && !pushSound.isPlaying)
        {
            pushSound.Play();
        }
    }
    */

}
