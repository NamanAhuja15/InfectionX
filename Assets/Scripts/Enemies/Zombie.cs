using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float movespeed,push,detection;
    private float x, y;
    private Vector2 velocity;
    public Vector3 left, right;
    private bool leftmove, rightmove, idle;
    private Rigidbody2D rb;
    private Animator animator;
    public bool dead,attack, run, detect;
    public GameObject zombie;
    void Start()
    {
        x = transform.localScale.x;
        y = transform.localScale.y;
        left = new Vector3(-x, y, 1);
        right = new Vector3(x, y, 1);
        rb = GetComponent<Rigidbody2D>();
        rightmove = true;
        animator = GetComponent<Animator>();
        attack = false;
        zombie=this.gameObject;
        dead = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!dead)
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
            dead = true;
        }
        if (!dead&&!detect)
        {
            if (rightmove)
            {
                transform.localScale = right;
                rb.velocity = new Vector2(movespeed, 0);
                velocity = rb.velocity;
            }
            if (leftmove)
            {
                transform.localScale = left;
                rb.velocity = new Vector2(-movespeed, 0);
                velocity = rb.velocity;
            }
            if (leftmove || rightmove)
            {
                run = true;
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        animator.SetBool("running", run);
        animator.SetBool("attack", attack);
    }
}
