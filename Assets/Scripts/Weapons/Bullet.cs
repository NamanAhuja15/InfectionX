using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed,damage;
    private float time;
    private Rigidbody2D rb;
    public GameObject player;
    public ParticleSystem Explode;
    private Vector3 left, right;

    void Start()
    {
        right = transform.localScale;
        left = -transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        if (player.transform.localScale.x > 0)
        {
            transform.localScale = right;
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            transform.localScale = left;
            rb.velocity = new Vector2(-speed, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 4f)
           Destroy(this.gameObject);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombie"))
        {
            collision.gameObject.GetComponent<Zombie_Health>().TakeDmg(damage);
            Instantiate(Explode, this.gameObject.transform.position, Quaternion.identity) ;
            Destroy(this.gameObject);
        }
    }
}
