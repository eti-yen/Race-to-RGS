using UnityEngine;
using System.Collections;

public class Battler : MonoBehaviour
{
	public int health;
	public float speed;
	public int attack;
	public int defense;
	public Attack hit;
	public AudioSource damageSound;
	public AudioSource dieSound;
	bool dying;
	
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
		if (health > 0 && damageSound != null)
			damageSound.Play();
	}

	protected void Die()
	{
		if (dying)
			return;
		dying = true;
		float waitTime = 1f;
		if (dieSound != null)
		{
			dieSound.Play();
			waitTime = dieSound.clip.length;
		}
		Destroy(gameObject, waitTime);
	}
}
