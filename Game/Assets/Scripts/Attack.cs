using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{
    public float force = 5f;

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
    }
}
