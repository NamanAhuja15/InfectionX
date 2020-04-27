using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private float x, y;
    private Vector2 velocity;

    private bool leftmove, rightmove, idle;
    private Rigidbody2D rb;
    private Animator animator;
    public float Movespeed;
    [HideInInspector]
    public GameObject Zombie_;
    [HideInInspector]
    public Vector3 Left, Right;
    [HideInInspector]
    public bool Dead, Attack, Run, Detect;
    void Start()
    {
        x = transform.localScale.x;
        y = transform.localScale.y;
        Left = new Vector3(-x, y, 1);
        Right = new Vector3(x, y, 1);
        rb = GetComponent<Rigidbody2D>();
        rightmove = true;
        animator = GetComponent<Animator>();
        Attack = false;
        Zombie_=this.gameObject;
        Dead = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Dead)
        {
            if (collision.gameObject.CompareTag("SpikesLeft"))
            {
                idle = false;
                rightmove = true;
                leftmove = false;
            }
            if (collision.gameObject.CompareTag("SpikesRight"))
            {
                idle = false;
                leftmove = true;
                rightmove = false;


            }
            if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Missile"))
            {
                if(this.gameObject.GetComponent<Zombie_Health>().Health>20)
                animator.SetTrigger("hurt");
            }
            
        }
    }
        // Update is called once per frame
        void Update()
    {
        if(gameObject.GetComponent<Zombie_Health>().Health<=0)
        {
            Dead = true;
        }
        if (!Dead&&!Detect)
        {
            if (rightmove)
            {
                transform.localScale = Right;
                rb.velocity = new Vector2(Movespeed, 0);
                velocity = rb.velocity;
            }
            if (leftmove)
            {
                transform.localScale = Left;
                rb.velocity = new Vector2(-Movespeed, 0);
                velocity = rb.velocity;
            }
            if (leftmove || rightmove)
            {
                Run = true;
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        animator.SetBool("running", Run);
        animator.SetBool("attack", Attack);
    }
}
