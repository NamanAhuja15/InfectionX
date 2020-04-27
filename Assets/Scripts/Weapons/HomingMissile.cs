using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour {
	public Vector2 Target;
	public float Speed = 5f;
	public float Damage;
	public float RotateSpeed = 200f;
	private GameObject[] list;
	private Rigidbody2D rb;
	private float time,destroy;
	public ParticleSystem Explode;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		time = 0f;
		Target = Vector2.zero;	
	}
	
	void FixedUpdate () {
		Vector2 direction = Target - rb.position;

		direction.Normalize();

		float rotateAmount = Vector3.Cross(direction, transform.up).z;

		rb.angularVelocity = -rotateAmount * RotateSpeed;
		rb.velocity = transform.up * Speed;
		
	}
	void Update()
	{
		list = GameObject.FindGameObjectsWithTag("Zombie");
		time += Time.deltaTime;
		destroy += Time.deltaTime;
		if (destroy > 5)
			Destroy(this.gameObject);
		if (Target == Vector2.zero)
		{
			if (time > 5f)
			{
				Target = new Vector2(1000, 1000);
			}
		}
		if (list != null)
		{
			for (int i = 0; i < list.Length; i++)
			{
				if (Vector2.Distance(transform.position, list[i].transform.position) <= 1000)
				{
					Target = list[i].transform.position;
				}
			}
		}
    }
	void OnTriggerEnter2D(Collider2D collide)
	{
		if (collide.CompareTag("Zombie"))
		{
			collide.gameObject.GetComponent<Zombie_Health>().TakeDmg(Damage);
			Instantiate(Explode, collide.transform.position, Quaternion.identity);
			Destroy(this.gameObject);
		}
	}

}
