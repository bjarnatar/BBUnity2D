﻿using UnityEngine;
using System.Collections;

public class AsteroidGameManager : MonoBehaviour
{
	public Vector2 stageArea = new Vector2(7.5f, 5.5f);

	public int startingAsteroids = 3;
	public int maxLargeAsteroids = 5;
	public float spawnFrequency = 5f;
	public float spawnVelocity = 2f;
	
	public Rigidbody2D asteroidPrefab;
	public TextMesh gameOverText;

	public int currentLargeAsteroids = 0;

	// Use this for initialization
	void Start ()
	{
		for (int i = 0 ; i < startingAsteroids ; ++i)
		{
			SpawnAsteroid();
		}

		InvokeRepeating("SpawnAsteroid", spawnFrequency, spawnFrequency);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void PlayerDied()
	{
		Invoke ("ReloadLevel", 3f);
		gameOverText.gameObject.SetActive(true);
	}

	void ReloadLevel()
	{
		Application.LoadLevel(0);
	}

	// TODO Make the "spawn frame" narrower around the screen. Build in a little buffer around the play area
	void SpawnAsteroid()
	{
		if (currentLargeAsteroids >= maxLargeAsteroids)
		{
			return; // We have the max number of large asteroids, so no room to spawn more right now
		}

		GameObject player = GameObject.FindGameObjectWithTag("Player");
		float distanceToPlayer = 0;
		float spawnPosX = Random.Range(-stageArea.x, stageArea.x);
		if (spawnPosX < 0)
		{
			spawnPosX -= stageArea.x;
		}
		if (spawnPosX > 0)
		{
			spawnPosX += stageArea.x;
		}

		float spawnPosY = Random.Range(-stageArea.y, stageArea.y);
		if (spawnPosY < 0)
		{
			spawnPosY -= stageArea.y;
		}
		if (spawnPosY > 0)
		{
			spawnPosY += stageArea.y;
		}
		Vector2 spawnPos = new Vector2(spawnPosX, spawnPosY);
		Vector2 targetPos = new Vector2(Random.Range (0, stageArea.x), Random.Range(0, stageArea.y));

		Rigidbody2D asteroid = (Rigidbody2D) Instantiate(asteroidPrefab, spawnPos, transform.rotation);
		asteroid.velocity = (targetPos - spawnPos).normalized * spawnVelocity;

		AsteroidResetPosition arp = asteroid.GetComponent<AsteroidResetPosition>();
		arp.wraparoundActive = false; // No wrapping until we have entered the stage area

		currentLargeAsteroids++;
	}
}
