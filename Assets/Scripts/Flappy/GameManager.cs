﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	public float levelSpeed = 3.0f;
	public float levelAcceleration = 0.1f;

	void Update ()
	{
		levelSpeed += Time.deltaTime * levelAcceleration;
	}

	public void PlayerDied()
	{
		// This simply reloads level 0.
		// TODO Make this a bit more proper
		Application.LoadLevel(0);
	}
}
