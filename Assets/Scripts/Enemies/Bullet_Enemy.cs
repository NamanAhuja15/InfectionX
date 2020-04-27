using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Enemy : MonoBehaviour
{
    public float Damage;
    public float RotateSpeed = 200f;
    public float Speed = 5f;
    private Animator anim;
    private Vector2 target;
    private float time,destroy,blink;
    private Rigidbody2D rb;
    private Light light1;

    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        light1 = gameObject.GetComponentInChildren<Light>();
    }
    void Update()
    {
        target = GameObject.Find("Player").transform.position;
        if (target == Vector2.zero)
        {
            if (time > 5f)
            {
                target = new Vector2(1000, 1000);
            }
        }
        destroy += Time.deltaTime;
        time += Time.deltaTime;
        blink += Time.deltaTime;
        if(blink>0.3f)
        {
            blink = 0f;
            if (!light1.enabled)
                light1.enabled = true;
            else
                light1.enabled = false;
        }
        if (destroy > 2.5f)
            Destroy(this.gameObject);
    }
    void FixedUpdate()
    {
        Vector2 direction = target - rb.position;

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * RotateSpeed;
        rb.velocity = transform.up * Speed;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player_Health>().TakeDamage(Damage);
            collision.gameObject.GetComponent<Animator>().SetTrigger("Hurt");
            anim.SetTrigger("Hit");
            Destroy(this.gameObject);
        }
    }
    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
