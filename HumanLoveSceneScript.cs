using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HumanLoveSceneScript : MonoBehaviour
{
    public GameObject human;
    public GameObject ghostman;
    public GameObject button;
    public GameObject text;
    public GameObject humanEndPos;
    public GameObject ghostmanEndPos;
    public GameObject heart;
    [SerializeField] private float duration;
    private float elapsedTime;
    public GameObject endSound;
    private bool hasPlayed = false;
    public GameObject humanAnimator;
    public GameObject ghostmanAnimator;
    public GameObject loveFoundText;

    private void Start()
    {
        LoveFound();
    }

    // Update is called once per frame
    void Update()
    {
        if(human.transform.position.x != humanEndPos.transform.position.x)
        {
            Movement();
        }

        if (human.transform.position.x == humanEndPos.transform.position.x)
        {
            if (humanAnimator == null)
            {
                Animator [] humanAnimators = human.GetComponentsInChildren<Animator>();

                foreach (Animator anim in humanAnimators)
                {
                    anim.SetFloat("Speed", 0);
                }
            }
            else
            {
                humanAnimator.GetComponent<Animator>().SetFloat("Speed", 0);
            }

            ghostmanAnimator.GetComponent<Animator>().SetFloat("Speed", 0);

            heart.SetActive(true);
            text.SetActive(true);
            StartCoroutine(ButtonAppear());
        }

        loveFoundText.GetComponent<TextMeshProUGUI>().text = "True Love Found! (" + PlayerPrefs.GetFloat("LoveFound") +  "/7)";
    }
    
    //move characters towards their end points
    private void Movement()
    {
        if (humanAnimator == null)
        {
            Animator[] humanAnimators = human.GetComponentsInChildren<Animator>();

            foreach (Animator anim in humanAnimators)
            {
                anim.SetFloat("Speed", 1);
            }
        }
        else
        {
            humanAnimator.GetComponent<Animator>().SetFloat("Speed", 1);
        }

        ghostmanAnimator.GetComponent<Animator>().SetFloat("Speed", 1);
        elapsedTime += Time.deltaTime;

        float percentComplete = elapsedTime / duration;

        human.transform.position = Vector2.Lerp(human.transform.position, humanEndPos.transform.position, percentComplete);
        ghostman.transform.position = Vector2.Lerp(ghostman.transform.position, ghostmanEndPos.transform.position, percentComplete);
        StartCoroutine(MoveIt());

        if(humanAnimator == null || !human.GetComponent<AudioSource>().isPlaying)
        {
            if (humanAnimator == null)
            {
                AudioSource[] humanAudio = human.GetComponentsInChildren<AudioSource>();

                foreach (AudioSource audio in humanAudio)
                {
                    if(!audio.isPlaying)
                    {
                        audio.volume = Random.Range(0.1f, 0.2f);
                        audio.pitch = Random.Range(1.3f, 1.4f);
                        audio.Play();
                    }
                }
            }
            else
            {
                human.GetComponent<AudioSource>().volume = Random.Range(0.1f, 0.2f);
                human.GetComponent<AudioSource>().pitch = Random.Range(1.3f, 1.4f);
                human.GetComponent<AudioSource>().Play();
            }
        }

        if (!ghostman.GetComponent<AudioSource>().isPlaying)
        {
            ghostman.GetComponent<AudioSource>().volume = Random.Range(0.2f, 0.3f);
            ghostman.GetComponent<AudioSource>().pitch = Random.Range(1.0f, 1.2f);
            ghostman.GetComponent<AudioSource>().Play();
        }

    }

    //jump characters to their end points
    private IEnumerator MoveIt()
    {
        yield return new WaitForSeconds(8f);
        human.transform.position = humanEndPos.transform.position;
        ghostman.transform.position = ghostmanEndPos.transform.position;
        if(!hasPlayed)
        {
            endSound.GetComponent<AudioSource>().Play();
            hasPlayed = true;
        }
    }

    //save the endgame state for use in the main menu
    private void LoveFound()
    {
        if (SceneManager.GetActiveScene().name== "HumanLoveCutscene" && PlayerPrefs.GetFloat("End1") != 1)
        {
            PlayerPrefs.SetFloat("LoveFound", PlayerPrefs.GetFloat("LoveFound") + 1);
            PlayerPrefs.SetFloat("End1", 1);
        }

        if (SceneManager.GetActiveScene().name == "CatLoveCutscene" && PlayerPrefs.GetFloat("End2") != 1)
        {
            PlayerPrefs.SetFloat("LoveFound", PlayerPrefs.GetFloat("LoveFound") + 1);
            PlayerPrefs.SetFloat("End2", 1);
        }

        if (SceneManager.GetActiveScene().name == "MultiHumanLoveCutscene" && PlayerPrefs.GetFloat("End3") != 1)
        {
            PlayerPrefs.SetFloat("LoveFound", PlayerPrefs.GetFloat("LoveFound") + 5);
            PlayerPrefs.SetFloat("End3", 1);
        }
    }

    //make the button appear
    private IEnumerator ButtonAppear()
    {
        yield return new WaitForSeconds(4f);
        button.SetActive(true);
    }

    //button returns to main menu
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
