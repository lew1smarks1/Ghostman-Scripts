using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGhostCollisions : MonoBehaviour
{
    private BoxCollider2D myCollider;
    public GameObject playerHuman;
    private AudioSource reviveSound;

    private void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
        reviveSound = GameObject.Find("ReviveSound").GetComponent<AudioSource>();
    }

    //If the player ghost collides with a heart, it changes to a human
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Heart"))
        {
            gameObject.SetActive(false);
            PlayerMovement.isHuman = true;
            Destroy(collision.gameObject);
            playerHuman.SetActive(true);
            PlayerHumanCollisions.hasCollided = false;
            reviveSound.Play();
        }
        //The player ghost ignores collisions with boxes, other humans and walls
        if (collision.gameObject.CompareTag("Box"))
        {
            Physics2D.IgnoreCollision(collision.collider, myCollider);
        }

        if (collision.gameObject.CompareTag("Villager"))
        {
            Physics2D.IgnoreCollision(collision.collider, myCollider);
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            Physics2D.IgnoreCollision(collision.collider, myCollider);
        }
    }

}
