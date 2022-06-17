using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage14AltEndScript : MonoBehaviour
{
    public GameObject human1;
    public GameObject human2;
    public GameObject human3;
    public GameObject human4;
    public GameObject human5;

    //script for the final secret ending that requires you to complete the final level with all 5 humans alive
    public void EndGame()
    {
        if (human1 == null || human2 == null || human3 == null || human4 == null || human5 == null)
        {
            End2();
        }
        else
        {
            End3();
        }
    }

    private void End2()
    {
        SceneManager.LoadScene("CatLoveCutscene");
    }

    private void End3()
    {
        SceneManager.LoadScene("MultiHumanLoveCutscene");
    }
}
