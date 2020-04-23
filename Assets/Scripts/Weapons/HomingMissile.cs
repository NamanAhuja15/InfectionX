using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour {
	public Vector2 target;
	public float speed = 5f;
	public float damage;
	public float rotateSpeed = 200f;
	private GameObject[] list;
	private Rigidbody2D rb;
	private float time,destroy;
	public ParticleSystem explode;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		time = 0f;
		target = Vector2.zero;	
	}
	
	void FixedUpdate () {
		Vector2 direction = target - rb.position;

		direction.Normalize();

		float rotateAmount = Vector3.Cross(direction, transform.up).z;

		rb.angularVelocity = -rotateAmount * rotateSpeed;
		rb.velocity = transform.up * speed;
		
	}
	void Update()
	{
		list = GameObject.FindGameObjectsWithTag("Zombie");
		time += Time.deltaTime;
		destroy += Time.deltaTime;
		if (destroy > 5)
			Destroy(this.gameObject);
		if (target == Vector2.zero)
		{
			if (time > 5f)
			{
				target = new Vector2(1000, 1000);
			}
		}
		if (list != null)
		{
			for (int i = 0; i < list.Length; i++)
			{
				if (Vector2.Distance(transform.position, list[i].transform.position) <= 1000)
				{
					target = list[i].transform.position;
				}
			}
		}
    }
	void OnTriggerEnter2D(Collider2D collide)
	{
		if (collide.CompareTag("Zombie"))
		{
			collide.gameObject.GetComponent<Zombie_Health>().TakeDmg(damage);
			Instantiate(explode, collide.transform.position, Quaternion.identity);
			Destroy(this.gameObject);
		}
	}

}
