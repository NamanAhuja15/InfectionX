using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    private bool move;
    public float speed;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
            {
            if (!move)
                move = true;
        }
        if(collision.gameObject.CompareTag("Ground"))
        {
            speed = -speed;
        }
    }
    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed, 0f);
    }
}
