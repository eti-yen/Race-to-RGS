using UnityEngine;
using System.Collections;

public class Enemy : Battler
{
	// Use this for initialization
	void Start()
	{
		health = 1;
		attack = 1;
		defense = 0;
		speed = 1f;
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}

	new public void Damage(int darmage)
	{
		health -= (darmage - defense);
		if (health <= 0)
			Die();
	}

	new protected void Die()
	{
		Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
		rb2d.velocity = rb2d.velocity.normalized * 9999f;
		//if (Mathf.Sign(rb2d.velocity.y) == 1)
			rb2d.AddForce(Vector2.up * 9999f, ForceMode2D.Impulse);
		base.Die();
	}
}
