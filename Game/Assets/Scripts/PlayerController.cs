using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameObject attack;

    Transform trans;
    Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        trans = GetComponent<Transform>();
        rb2d = GetComponent<Rigidbody2D>();
    }
	
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 movement = new Vector2();
        movement.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        movement.y = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        rb2d.AddForce(movement, ForceMode2D.Impulse);
        if (Input.GetKeyDown(KeyCode.Space))
        {
			Vector3 offset;
			Vector3 rotation = new Vector3(0f, 0f, 0f);
			if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") == 0)
			{
				if (Input.GetAxisRaw("Horizontal") == -1)
				{
					offset = new Vector3(-0.7f, 0f, 0f);
					rotation = new Vector3(0, 0, 180);
				}
				else
					offset = new Vector3(0.7f, 0f, 0f);
			}
			else
			{
				if (Input.GetAxisRaw("Vertical") == 1)
				{
					offset = new Vector3(0f, 0.7f, 0f);
					rotation = new Vector3(0, 0, 90);
				}
				else
				{
					offset = new Vector3(0f, -0.7f, 0f);
					rotation = new Vector3(0, 0, 270);
				}
			}
			GameObject hit = (GameObject)Instantiate(attack, trans.position + offset, Quaternion.identity, trans);
			hit.transform.Rotate(rotation);
            Destroy(hit, 0.1f);
        }
    }
}
