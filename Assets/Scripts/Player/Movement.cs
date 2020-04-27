using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class Movement : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Vector3 left, right;
    private float x, y,movespeed,lastclicked;
    private bool candoublejump,playerJumped,doublejumped,running,slide;
    private Animator animator;
    private Collider2D collide;
    private float inputHorizontal, landing;
    private float inputVertical, gravity;

    public string horizontalAxis = "Horizontal";
    public string verticalAxis = "Vertical";
    public string jumpButton = "Jump";
    public float Groundspeed, Airspeed, Initialjumpforce;
    public bool IsGrounded;

    void Start()
    {
        x = transform.localScale.x;
        y = transform.localScale.y;
        left = new Vector3(-x, y, 1);
        right = new Vector3(x, y, 1);
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        collide = GetComponent<CircleCollider2D>();
        inputHorizontal = SimpleInput.GetAxis(horizontalAxis);
        inputVertical = SimpleInput.GetAxis(verticalAxis);
        gravity = rigid.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        landing += Time.deltaTime;
        MovementInput();
        animator.SetBool("Running", running);
        animator.SetBool("Jumping", playerJumped);
        animator.SetBool("DoubleJump", doublejumped);
        animator.SetBool("Slide", slide);
        inputHorizontal = SimpleInput.GetAxis(horizontalAxis);
        inputVertical = SimpleInput.GetAxis(verticalAxis);
    }

    private void MovementInput()
    {
       
        if(inputHorizontal<0)

        {
            if (IsGrounded && !playerJumped)
            {
                running = true;
            }
            transform.localScale = left;
            transform.Translate(Vector2.right*inputHorizontal * movespeed * Time.deltaTime);
        }
      
        if(inputHorizontal>0)
        {
            if (IsGrounded && !playerJumped)
            {
                running = true;
            }
            transform.localScale = right;
            transform.Translate(Vector2.right*inputHorizontal * movespeed * Time.deltaTime);
        }

        if (inputVertical < -0.5f)
        {
            if (Time.time - lastclicked > 1)
            {
                slide = true;
                collide.enabled = false;
            }
        }
        if(inputVertical>-0.5f)
            {
            slide = false;
            collide.enabled = true;
        }

        if (inputHorizontal == 0)
            running = false;
          
       
       if(inputVertical>0.5f&&landing>1f)
        {
            if (IsGrounded&&!playerJumped)

            {
                landing = 0f;
                playerJumped = true;
               
                rigid.AddForce(transform.up * Initialjumpforce,ForceMode2D.Impulse);
                candoublejump = true;
            }
           /* else if(!isGrounded)
            {
                if (candoublejump)
                {
                    DoubleJump();
                }
            }*/
        }
        }
    private void DoubleJump()
    {
        doublejumped = true;
        candoublejump = false;
        rigid.velocity = new Vector2(0, 0);
        rigid.AddForce(transform.up * Initialjumpforce*1.2f, ForceMode2D.Impulse);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
            doublejumped = false;
            movespeed = Groundspeed;
            playerJumped = false;
            rigid.gravityScale = gravity;
            landing = 0f;
        }
        if(collision.gameObject.CompareTag("Zombie"))
        {
            animator.SetTrigger("Hurt");
            this.gameObject.GetComponent<Player_Health>().TakeDamage(5);
        }
        if(collision.gameObject.CompareTag("Platform"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = rigid.velocity;
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = false;
            running = false;
            movespeed = Airspeed;
        }
    }
    public void Fall()
    {
        rigid.AddForce(-transform.up * Initialjumpforce*1.5f , ForceMode2D.Impulse);
        rigid.gravityScale *= 3;
    }
    public void GetUp()
    {
        slide = false;
        lastclicked = Time.time;
    }
    }
