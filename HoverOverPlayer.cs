using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverOverPlayer : MonoBehaviour
{
    //Main Menu player running script
    public GameObject player;

    //scripts activate on button
    //On hover script
    public void HoverOn()
    {
        player.SetActive(true);
        player.GetComponentInChildren<Animator>().SetFloat("Speed", 1);
        player.transform.position = new Vector3(-0.1f, transform.position.y, 0);
    }

    public void HoverOnLong()
    {
        player.SetActive(true);
        player.GetComponentInChildren<Animator>().SetFloat("Speed", 1);
        player.transform.position = new Vector3(0.05f, transform.position.y, 0);
    }
    
    //On hover exit script
    public void HoverExit()
    {
        player.SetActive(false);
    }


}
