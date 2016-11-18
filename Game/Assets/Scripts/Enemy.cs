using UnityEngine;
using System.Collections;
using System;

public class Enemy : Battler
{
	public event Action<Enemy> OnDie;

	public float range = 0.7f;

	public float attackDelay = 0.5f;
	protected float lastAttackTime;

	protected Rigidbody2D rb2d;
	protected Transform target;

	// Use this for initialization
	protected void Start()
	{
		target = GameObject.FindGameObjectWithTag("Player").transform;
		rb2d = GetComponent<Rigidbody2D>();
		lastAttackTime = Time.time;
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}

	protected void FixedUpdate()
	{
		if (health <= 0)
			Die();
		else
			Behavior();
	}

	protected void Behavior()
	{
		if (target.position.x < transform.position.x)
		{
			if (transform.position.x - target.position.x <= range + 0.2f + 0.5f * target.localScale.x + 0.5f * transform.localScale.x)
				Attack(new Vector3(-range, 0f, 0f), new Vector3(0, 0, 180), attack, .1f);
			else
				rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
		}
		else if (target.position.x > transform.position.x)
		{
			if (target.position.x - transform.position.x <= range + 0.2f + 0.5f * target.localScale.x + 0.5f * transform.localScale.x)
				Attack(new Vector3(range, 0f, 0f), new Vector3(0, 0, 0), attack, .1f);
			else
				rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
		}
	}

	new protected void Die()
	{
		Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
		if (rb2d.velocity == Vector2.zero)
			rb2d.velocity = Vector2.right + Vector2.up;
		if (rb2d.velocity.y == 0)
			rb2d.velocity += Vector2.up;
		rb2d.AddForce(rb2d.velocity.normalized * 50, ForceMode2D.Impulse);
		GetComponent<Collider2D>().enabled = false;
		if (OnDie != null)
			OnDie(this);
		base.Die();
	}

	protected void Attack(Vector3 offset, Vector3 rotation, int strength, float force)
	{
		if (Time.time - lastAttackTime > attackDelay)
		{
			lastAttackTime = Time.time;
			base.Attack(offset, rotation, strength, force);
		}
	}
}
