using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage12AltEndScript : MonoBehaviour
{
    public GameObject triggerHeart;
    public GameObject message1;
    public GameObject message2;

    //if the trigger heart has been taken then the message changes and transition to alt end cutscene
    void Update()
    {
        if (triggerHeart == null)
        {
            message1.SetActive(false);
            message2.SetActive(true);
            StartCoroutine(TriggerAltCutscene());
        }
    }
    
    //loads in the lvl 12 alternate cutscene
    private IEnumerator TriggerAltCutscene()
    {
        yield return new WaitForSeconds(8f);
        SceneManager.LoadScene("HumanLoveCutscene");
    }
}
