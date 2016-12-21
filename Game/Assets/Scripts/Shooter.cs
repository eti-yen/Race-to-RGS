using UnityEngine;
using System.Collections;

public class Shooter : Enemy
{
	public Vector2[] waypoints;
	//int index;
	Transform bulletSpawn;

	new protected void Start()
	{
		//index = 0;
		bulletSpawn = transform.GetChild(0);
		base.Start();
	}

	// Update is called once per frame
	void Update()
	{
	
	}

	new protected void FixedUpdate()
	{
		if (health <= 0)
			Die();
		else
			Behavior();
	}

	new protected void Behavior()
	{
		Attack();
	}

	protected void Attack()
	{
		if (Time.time - lastAttackTime > attackDelay)
		{
			Vector3 distance = target.position - bulletSpawn.position;
			float angle = Vector2.Angle(-bulletSpawn.right, distance);
			Vector3 rotation;
			if (target.position.y < bulletSpawn.position.y)
				rotation = new Vector3(0, 0, angle);
			else
				rotation = new Vector3(0, 0, -angle);
			GameObject durr = (GameObject)Instantiate(hit.gameObject, bulletSpawn.position, bulletSpawn.rotation);

			durr.transform.Rotate(rotation);
			durr.GetComponent<Attack>().damage = attack;
			durr.GetComponent<Attack>().force = 0.2f;

			Destroy(durr, 5f);
			lastAttackTime = Time.time;
		}
	}
}
