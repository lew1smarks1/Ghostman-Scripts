using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextMove : MonoBehaviour
{
    public GameObject target;

    //attaches text to move with the target object
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
        }
        else if (!target.activeInHierarchy)
        {
            gameObject.GetComponent<TextMeshProUGUI>().enabled = false;
        }
        else if(target.activeInHierarchy)
        {
            gameObject.GetComponent<TextMeshProUGUI>().enabled = true;
            transform.position = target.transform.position;
        }
    }

}
