using UnityEngine;
using System.Collections;

public class Projectile : Attack
{
	public float speed;

	// Use this for initialization
	void Start()
	{
	
	}
	
	// Update is called once per frame
	void Update()
	{
		transform.Translate(-transform.right * speed * Time.deltaTime, Space.World);
	}

	new protected void OnTriggerEnter2D(Collider2D other)
	{
		PlayerController victim = other.gameObject.GetComponent<PlayerController>();
		if (victim != null)
		{
			Rigidbody2D hitThing = victim.GetComponent<Rigidbody2D>();
			hitThing.velocity = Vector2.zero;
			hitThing.AddForce(-transform.right * force, ForceMode2D.Impulse);
			victim.Damage(damage);
			gameObject.SetActive(false);
		}
	}
}
