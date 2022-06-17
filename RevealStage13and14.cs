using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealStage13and14 : MonoBehaviour
{
    
    public GameObject button13;
    public GameObject button14;

    private void Start()
    {
        SetLocks();
    }

    private void SetLocks()
    {
        if (!PlayerPrefs.HasKey(button13.name))
        {
            PlayerPrefs.SetFloat(button13.name, 0);
        }
        if (!PlayerPrefs.HasKey(button14.name))
        {
            PlayerPrefs.SetFloat(button14.name, 0);
        }
    }

    //hides hidden stages 13 & 14 unless you've entered them
    void Update()
    {
        if (PlayerPrefs.GetFloat(button13.name) == 0)
        {
            button13.SetActive(false);
        }
        else if (PlayerPrefs.GetFloat(button13.name) == 1)
        {
            button13.SetActive(true);
        }

        if (PlayerPrefs.GetFloat(button14.name) == 0)
        {
            button14.SetActive(false);
        }
        else if (PlayerPrefs.GetFloat(button14.name) == 1)
        {
            button14.SetActive(true);
        }
    }
}
