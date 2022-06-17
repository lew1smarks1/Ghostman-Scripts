using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatRunAway : MonoBehaviour
{
    public GameObject player;
    private bool running = false;

    //Cat runs away when the player comes close
    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 1)
        {
            running = true;
        }
        MoveCat();
    }

    private void MoveCat()
    {
        if(running)
        {
            gameObject.GetComponent<Animator>().SetFloat("Speed", 1);
            gameObject.transform.Translate(0.3f * Time.deltaTime, 0, 0);
            StartCoroutine(DestroyCat());
        }

    }
    private IEnumerator DestroyCat()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
