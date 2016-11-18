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

	protected void Attack(Vector3 offset, Vector3 rotation, int strength, float force, float wait = 0.1f)
	{
		GameObject durr = (GameObject)Instantiate(hit.gameObject, transform.position + offset, Quaternion.identity, transform);
		durr.transform.Rotate(rotation);
		durr.GetComponent<Attack>().damage = strength;
		durr.GetComponent<Attack>().force = force;

		Destroy(durr, wait);
	}

	public void Damage(int darmage)
	{
		int damage = darmage - defense;
		if (damage < 0)
			damage = 0;
		health -= damage;
	}

	protected void Die()
	{
		Destroy(gameObject, 1f);
	}
}
