using UnityEngine;
using System.Collections;

public class PlayerController : Battler
{
	bool facingRight;
    Rigidbody2D rb2d;
	Animator animor;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
		animor = GetComponentInChildren<Animator>();
		facingRight = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Vector3 offset;
			Vector3 rotation = new Vector3(0f, 0f, 0f);
			if (Input.GetAxisRaw("Vertical") == 0)
			{
				if (!facingRight)
				{
					offset = new Vector3(-1.7f, 0f, 0f);
					rotation = new Vector3(0, 0, 180);
				}
				else
					offset = new Vector3(1.7f, 0f, 0f);
			}
			else
			{
				if (Input.GetAxisRaw("Vertical") == 1)
				{
					offset = new Vector3(0f, 2f, 0f);
					rotation = new Vector3(0, 0, 90);
				}
				else
				{
					offset = new Vector3(0f, -1.7f, 0f);
					rotation = new Vector3(0, 0, 270);
				}
			}
			animor.SetTrigger("Attack");
			Attack(offset, rotation, attack, 50f, .5f);
		}
		else
		{
			Vector2 movement = new Vector2();
			movement.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
			if ((Input.GetAxis("Horizontal") > 0 && !facingRight) || (Input.GetAxis("Horizontal") < 0 && facingRight))
				Flip();
			movement.y = Input.GetAxis("Vertical") * speed * Time.deltaTime;
			animor.SetBool("Moving", movement.magnitude > 0);
			rb2d.AddForce(movement, ForceMode2D.Impulse);
		}
    }

	void Flip()
	{
		facingRight = !facingRight;
		transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
	}
}
