using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4TextScript : MonoBehaviour
{
    public GameObject player;
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;

    //Text pops up when player reaches a certain point in the level
    void Update()
    {
        if (player.transform.position.x > -0.7f)
        {
            text1.SetActive(true);
        }
        if(player.transform.position.x > -0.2f)
        {
            text2.SetActive(true);
        }
        if(player.transform.position.x > 0.1f)
        {
            text3.SetActive(true);
        }
    }
}
