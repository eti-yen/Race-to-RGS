using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{
	public int damage;
    public float force;

    // Use this for initialization
    void Start()
    {
	
    }
	
    // Update is called once per frame
    void Update()
    {
	
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D hitThing = other.gameObject.GetComponent<Rigidbody2D>();
		if (hitThing != null)
		{
			hitThing.velocity = Vector2.zero;
			hitThing.AddForce(transform.right * force, ForceMode2D.Impulse);
		}
		Battler victim = other.gameObject.GetComponent<Battler>();
		if (victim != null)
			victim.Damage(damage);
    }
}
