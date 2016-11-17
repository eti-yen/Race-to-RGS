using UnityEngine;
using System.Collections;

public class PlayerController : Battler
{
    Rigidbody2D rb2d;
	Animator animor;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
		animor = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
			animor.SetTrigger("Attack");
			Attack(offset, rotation, attack, 10f);
		}
		else
		{
			Vector2 movement = new Vector2();
			animor.SetBool("Moving", movement.magnitude > 0);
			movement.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
			movement.y = Input.GetAxis("Vertical") * speed * Time.deltaTime;
			rb2d.AddForce(movement, ForceMode2D.Impulse);
		}
    }
}
