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
		transform.Translate(-transform.right * speed * Time.deltaTime);
	}

	new protected void OnTriggerEnter2D(Collider2D other)
	{
		Rigidbody2D hitThing = other.gameObject.GetComponent<Rigidbody2D>();
		if (hitThing != null)
		{
			hitThing.velocity = Vector2.zero;
			hitThing.AddForce(-transform.right * force, ForceMode2D.Impulse);
		}
		Battler victim = other.gameObject.GetComponent<Battler>();
		if (victim != null)
			victim.Damage(damage);
		gameObject.SetActive(false);
	}
}
