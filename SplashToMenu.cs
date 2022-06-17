using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashToMenu : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(SceneChange());
    }
    //splash menu at the beginning fade in and out
    IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("MainMenu");
    }
}
