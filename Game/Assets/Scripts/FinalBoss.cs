using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FinalBoss : Enemy
{
	public Text[] endMessages;
	PlayerController player;
	Animator pleeeeeeya;

	// Use this for initialization
	new void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		pleeeeeeya = player.transform.GetComponentInChildren<Animator>();
		player.enabled = false;
		pleeeeeeya.enabled = false;
	}
	
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();
		if ((!player.enabled || !pleeeeeeya.enabled) && Input.anyKeyDown)
		{
			player.enabled = true;
			pleeeeeeya.enabled = true;
		}
		else if (health < 0)
			Die();
	}

	new void FixedUpdate()
	{
	}

	new protected void Die()
	{
		endMessages[0].text = "Mr. The Bad Guy is defeated!";
		endMessages[0].fontSize = 70;
		endMessages[1].text = "To be continued...?";
		endMessages[2].text = "(Hopefully not).";
		base.Die();
	}
}
