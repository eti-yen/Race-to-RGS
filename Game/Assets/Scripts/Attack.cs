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
			other.GetComponent<Rigidbody2D>().AddForce(transform.TransformDirection(Vector2.right) * force, ForceMode2D.Impulse);
		Battler victim = other.gameObject.GetComponent<Battler>();
		if (victim != null)
			victim.Damage(damage);
    }
}
