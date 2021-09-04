using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;

    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    bool jump = false;

    public static bool attackOne = false;

    float attackfloat = 0f;

    public static int playerHealth = 10;

    float waitSeconds = 0.5f;

    public ParticleSystem dust;

    public ParticleSystem attack;

    public CircleCollider2D cc;

    public bool canMove;

    /*
    private float lastY;
    public float FallingThreshold = -0.01f;
    //[HideInInspector]
    public bool Falling = false;
    */



    AudioSource walkAudio;



    void Start()
    {

        walkAudio = GetComponent<AudioSource>();
        cc.enabled = false;
        //lastY = transform.position.y;
        canMove = true;

    }

    
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        /////////////////////
        if(canMove && Input.GetButtonDown("Jump"))
        {
            PlayerSoundManger.PlayerSound("playerJump");
            jump = true;
            animator.SetBool("IsJumping", true);
            CreateDust();
        }
        /////////////////////
        if (canMove && Input.GetKeyDown(KeyCode.X))
        {
            PlayerSoundManger.PlayerSound("playerSword");
            attackOne = true;
            animator.SetBool("IsAttackingOne", true);
            cc.enabled = true;
            CreateAttackParticle();
            StartCoroutine(WaitForHalfASecond());
            attackfloat += 1;
        }
        /////////////////////
        if (canMove && horizontalMove > 0f || horizontalMove < 0f)
        {
            /////////////////////
            if (!walkAudio.isPlaying)
            {
                walkAudio.Play();
                /////////////////////
                if (jump == true)
                {
                    walkAudio.Stop();
                }
            }
        }
        /////////////////////
        else
        {
            walkAudio.Stop();
        }


    }


    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }


    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
        attackOne = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy") && attackOne == false)
        {
            playerHealth -= 1;
            animator.SetBool("IfHit", true);
            PlayerSoundManger.PlayerSound("playerHit");
            StartCoroutine(WaitForHalfASecond());
            if (playerHealth == 0)
            {
                animator.SetBool("IsDead", true);
                PlayerSoundManger.PlayerSound("playerDeath");
                horizontalMove = 0f;
                StartCoroutine(WaitForHalfASecond());
            }
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("EndPoint"))
        {
            canMove = false;
            horizontalMove = 0f;
            runSpeed = 0f;
            GameEvents.InvokeDialogueInitiated();
        }
    }


    IEnumerator WaitForHalfASecond()
    {
        yield return new WaitForSeconds(waitSeconds);
        animator.SetBool("IsAttackingOne", false);
        animator.SetBool("IfHit", false);
        cc.enabled = false;
        if (playerHealth == 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    IEnumerable WaitForSeconds()
    {
        yield return new WaitForSeconds(waitSeconds);
        SceneManager.LoadScene(2);

    }


    public void CreateDust()
    {
        dust.Play();
    }

    public void CreateAttackParticle()
    {
        attack.Play();
    }


}
