using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movers : MonoBehaviour
{
    private BoxCollider2D myCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    private AudioSource footSteps;

    [SerializeField] private Animator animator;

    private void Start()
    {
        footSteps = GetComponent<AudioSource>();
        myCollider = GetComponent<BoxCollider2D>();
    }

    private void LateUpdate()
    {
        if (!Winner.winGame && !PauseScreenScript.isPaused)
        {
            Movement();
            Sound();
        }

    }
    
    //footstep sounds
    private void Sound()
    {
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && !footSteps.isPlaying)
        {
            footSteps.volume = Random.Range(0.1f, 0.2f);
            footSteps.pitch = Random.Range(1.3f, 1.4f);
            footSteps.Play();
        }
    }

    //movement for human
    private void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (x>0 || x<0)
        {
            animator.SetFloat("Speed", Mathf.Abs(x));
        }

        else if (y>0 || y<0)
        {
            animator.SetFloat("Speed", Mathf.Abs(y));
        }

        else
        {
            animator.SetFloat("Speed", 0);
        }

        moveDelta = new Vector3(x, y, 0);

        //swap sprite direction on left or right

        if (moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        
        //Cast a box in the direction we're moving, if null then move
        hit = Physics2D.BoxCast(transform.position, myCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking", "BlockAll"));
        if (hit.collider == null)
        {
            //Movement
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position, myCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking", "BlockAll"));
        if (hit.collider == null)
        {
            //Movement
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
        
    }
}
