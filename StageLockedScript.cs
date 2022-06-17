using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageLockedScript : MonoBehaviour
{
    void Start()
    {
        SetLocks();
    }

    //sets up player prefs
    private void SetLocks()
    {
        if (!PlayerPrefs.HasKey(gameObject.name))
        {
            PlayerPrefs.SetFloat(gameObject.name, 0);
        }
    }

    //if you have completed the previous level then the next level becomes unlocked
    void Update()
    {
        if(PlayerPrefs.GetFloat(gameObject.name) == 0)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        else if(PlayerPrefs.GetFloat(gameObject.name) == 1)
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
    }
}
