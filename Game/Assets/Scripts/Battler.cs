using UnityEngine;
using System.Collections;

public class Battler : MonoBehaviour
{
	public int health;
	public float speed;
	public int attack;
	public int defense;
	public Attack hit;

	// Use this for initialization
	void Start()
	{
	
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}

	protected void Attack(Vector3 offset, Vector3 rotation, int strength, float force)
	{
		GameObject durr = (GameObject)Instantiate(hit.gameObject, transform.position + offset, Quaternion.identity, transform);
		durr.transform.Rotate(rotation);
		durr.GetComponent<Attack>().damage = strength;
		durr.GetComponent<Attack>().force = force;

		Destroy(durr, 0.1f);
	}

	public void Damage(int darmage)
	{
		health -= (darmage - defense);
		if (health <= 0)
			Die();
	}

	protected void Die()
	{
		Destroy(gameObject, 0.5f);
	}
}
