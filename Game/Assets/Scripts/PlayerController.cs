using UnityEngine;
using System.Collections;

public class PlayerController : Battler
{
	public float attackDelay = 0.5f;
	protected float lastAttackTime;

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

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();
	}

    // Update is called once per frame
    void FixedUpdate()
    {
		if (Input.GetKeyDown(KeyCode.Space) && Time.time - attackDelay >= lastAttackTime)
		{
			Vector3 offset = Vector3.zero;
			Vector3 rotation = new Vector3(0f, 0f, 0f);
			string dir = "";
			if (Input.GetAxisRaw("Vertical") == 0)
			{
				if (!facingRight)
				{
					rotation = new Vector3(0, 0, 180);
					offset = new Vector3(-1.7f, 0f, 0f);
				}
				else
					offset = new Vector3(1.7f, 0f, 0f);
			}
			else
			{
				if (Input.GetAxisRaw("Vertical") == 1)
				{
					offset = new Vector3(0f, 1.7f, 0f);
					rotation = new Vector3(0, 0, 90);
					dir = "Up";
				}
				else
				{
					offset = new Vector3(0f, -0.5f, 0f);
					rotation = new Vector3(0, 0, 270);
					dir = "Down";
				}
				if (facingRight)
					offset += new Vector3(1f, 0f, 0f);
				else
					offset += new Vector3(-1f, 0f, 0f);
			}
			animor.SetTrigger(dir + "Attack");
			Attack(offset, rotation, attack, 50f, .5f);
			lastAttackTime = Time.time;
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

	new protected void Damage(int darmage)
	{
		StartCoroutine(TurnRed());
		base.Damage(darmage);
	}

	void Flip()
	{
		facingRight = !facingRight;
		transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
	}

	IEnumerator TurnRed()
	{
		SpriteRenderer dur = GetComponentInChildren<SpriteRenderer>();
		for (int i = 0; i < 3; i++)
		{
			while (dur.color.g >= 122 + 0.5f)
			{
				dur.color = Color.Lerp(dur.color, new Color(255f, 122f, 122f), Time.deltaTime * 7f);
				yield return null; 
			}
			while (dur.color.g <= 255 - 0.5f)
			{
				dur.color = Color.Lerp(dur.color, new Color(255f, 122f, 122f), Time.deltaTime * 7f);
				yield return null; 
			}
		}
		dur.color = Color.white;
	}
}
