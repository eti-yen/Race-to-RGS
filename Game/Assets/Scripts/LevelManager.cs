using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
	public List<Enemy> enemies;
	public GameObject barrier;
	
	// Use this for initialization
	void Start()
	{
		foreach (Enemy e in enemies)
			e.OnDie += EraseEnemyFromExistence;
	}
	
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();
	}

	void EraseEnemyFromExistence(Enemy enenenenemy)
	{
		enemies.Remove(enenenenemy);
		if (enemies.Count <= 0)
			barrier.SetActive(false);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
