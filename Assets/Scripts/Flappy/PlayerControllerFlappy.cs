﻿using UnityEngine;
using System.Collections;

public class PlayerControllerFlappy : MonoBehaviour
{
	public float jumpForce = 5;
	
	private GameManager gm;
	
	void Start ()
	{
		gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}

	void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			rigidbody2D.velocity = Vector2.up * jumpForce;
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		// This means we died
		PlayerScoreFlappy score = GetComponent<PlayerScoreFlappy>();
		if (score)
		{
			score.UpdateHighScoreOnDeath();
		}

		gm.PlayerDied();
	}
}
