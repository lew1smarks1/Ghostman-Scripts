using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMover : MonoBehaviour
{
    //I wanted to try use LERP to control the human running in a box on the start screen
    [SerializeField] private Transform bottomLeft;
    [SerializeField] private Transform bottomRight;
    [SerializeField] private Transform topLeft;
    [SerializeField] private Transform topRight;
    [SerializeField] private float duration;
    [SerializeField] private Animator animator;
    private bool TL;
    private bool TR;
    private bool BL;
    private bool BR;
    private float elapsedTime;

    private void Start()
    {
        BR = true;
    }

    // Update is called once per frame
    private void Update()
    {
        MovementBR();
        MovementBL();
        MovementTL();
        MovementTR();
        
    }
    
    //runs Bottom Right to Bottom Left
    private void MovementBR()
    {


        animator.SetFloat("Speed", 1);

        if(BR)
        {
            elapsedTime += Time.deltaTime;

            float percentComplete = elapsedTime / duration;

            transform.localScale = new Vector3(-1, 1, 1);
            transform.position = Vector2.Lerp(bottomRight.position, bottomLeft.position, percentComplete);

            if(transform.position.x == bottomLeft.position.x)
            {
                BR = false;
                BL = true;

                elapsedTime = 0;
            }

        }
    }
    
    //runs Bottom Left to Top Left
    private void MovementBL()
    {
        if (BL)
        {
            elapsedTime += Time.deltaTime;

            float percentComplete = elapsedTime / duration;

            transform.position = Vector2.Lerp(bottomLeft.position, topLeft.position, percentComplete);

            if (transform.position.y == topLeft.position.y)
            {
                BL = false;
                TL = true;

                elapsedTime = 0;
            }
        }
    }

    //runs Top Left to Top Right
    private void MovementTL()
    {
        if (TL)
        {
            elapsedTime += Time.deltaTime;

            float percentComplete = elapsedTime / duration;

            transform.localScale = Vector3.one;
            transform.position = Vector2.Lerp(topLeft.position, topRight.position, percentComplete);

            if (transform.position.x == topRight.position.x)
            {
                TL = false;
                TR = true;

                elapsedTime = 0;
            }

        }
    }

    //runs Top Right to Bottom Right
    private void MovementTR()
    {
        if (TR)
        {
            elapsedTime += Time.deltaTime;

            float percentComplete = elapsedTime / duration;

            transform.position = Vector2.Lerp(topRight.position, bottomRight.position, percentComplete);
            if (transform.position.y == bottomRight.position.y)
            {
                TR = false;
                BR = true;

                elapsedTime = 0;
            }
        }
    }

}
