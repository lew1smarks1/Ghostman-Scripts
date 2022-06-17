using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostToHuman : MonoBehaviour
{
    public GameObject villager;
    private AudioSource humanReviveSound;

    private void Start()
    {
        humanReviveSound = GameObject.Find("ReviveSound").GetComponent<AudioSource>();
    }

    //when a ghost is touched by a heart, destroy the heart and change the ghost to a human
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Heart"))
        {
            humanReviveSound.Play();
            gameObject.SetActive(false);
            villager.SetActive(true);
            Destroy(collision.gameObject);
        }
    }

}
