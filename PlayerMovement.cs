using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public BoxCollider2D humanPlayerCollider;
    public BoxCollider2D ghostPlayerCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    public static bool isHuman = true;
    public GameObject playerGhost;
    public GameObject playerHuman;
    private AudioSource footSteps;

    [SerializeField] private Animator humanAnimator;

    private void Start()
    {
        footSteps = gameObject.GetComponent<AudioSource>();
    }

    private void Awake()
    {
        isHuman = true;
    }

    //Player or ghost moves if the game isn't won
    private void Update()
    {
        if (!Winner.winGame && isHuman && !PauseScreenScript.isPaused)
        {
            HumanMovement();
            Sound();
        }
        else if (!Winner.winGame && !isHuman && !PauseScreenScript.isPaused)
        {
            GhostMovement();
        }
    }

    //footstep sounds
    private void Sound()
    {
        if (isHuman && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && !footSteps.isPlaying)
        {
            footSteps.volume = Random.Range(0.2f, 0.3f);
            footSteps.pitch = Random.Range(1.0f, 1.2f);
            footSteps.Play();
        }
    }
    //Human movement using boxcast
    private void HumanMovement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");


        if (x > 0 || x < 0)
        {
            humanAnimator.SetFloat("Speed", Mathf.Abs(x));
        }

        else if (y > 0 || y < 0)
        {
            humanAnimator.SetFloat("Speed", Mathf.Abs(y));
        }

        else
        {
            humanAnimator.SetFloat("Speed", 0);
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

        //Cast a box in the direction we're moving, if null then move. Blocked by objects in the Actor, Blocking or BlockAll Layers
        hit = Physics2D.BoxCast(transform.position, humanPlayerCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking", "BlockAll"));
        if (hit.collider == null)
        {
            //Movement
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position, humanPlayerCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking", "BlockAll"));
        if (hit.collider == null)
        {
            //Movement
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }

    }
    
    //Ghost movement using boxcast
    private void GhostMovement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveDelta = new Vector3(x, y, 0);

        //swap sprite direction on left or right
        if (moveDelta.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (moveDelta.x < 0)
        {
            transform.localScale = Vector3.one;
        }

        //Cast a box in the direction we're moving, if null then move
        hit = Physics2D.BoxCast(transform.position, ghostPlayerCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Ghost", "BlockAll"));
        if (hit.collider == null)
        {
            //Movement

            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position, ghostPlayerCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Ghost", "BlockAll"));
        if (hit.collider == null)
        {
            //Movement
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }

    }

}
