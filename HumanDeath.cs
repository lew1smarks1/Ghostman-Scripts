using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanDeath : MonoBehaviour
{
    private AudioSource humanDeathSound;
    private bool humanHasCollided = false;

    private void Awake()
    {
        humanHasCollided = false;
    }
    private void Start()
    {
        humanDeathSound = GameObject.Find("HumanDeathSound").GetComponent<AudioSource>();
    }

    //when human touches a ghost, it is destroyed
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ghost") && !humanHasCollided)
        {
            humanHasCollided = true;
            humanDeathSound.Play();
            Destroy(collision.gameObject.transform.parent.gameObject);
            Destroy(gameObject);
        }
    }
}
