using UnityEngine;
using System.Collections;

public class AsteroidResetPosition : MonoBehaviour
{
	public bool wraparoundActive = true;

	private Vector2 stageArea;
	private AsteroidGameManager agm;

	void Start()
	{
		agm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<AsteroidGameManager>();
		if (agm == null)
		{
			Debug.LogError("Could not find the AsteroidGameManager. Please add one to the scene!");
		}
	}

	void Update ()
	{
		// Update stage area from Game Manager just in case it has changed.
		stageArea = agm.stageArea;

		if (wraparoundActive)
		{
			ResetPositionOnWraparound();
		}
		else
		{ // We want to set wraparound to active if the object has entered the stage area
			if (IsObjectInStageArea())
			{ // We have entered the stage area, so enable wraparound like normal
				wraparoundActive = true;
			}
		}
	}

	bool IsObjectInStageArea()
	{
		if (transform.position.x < -stageArea.x || transform.position.x > stageArea.x)
		{ // Object is outside stage area
			return false;
		}

		if (transform.position.y < -stageArea.y || transform.position.y > stageArea.y)
		{ // Object is outside stage area
			return false;
		}

		return true;
	}

	// This function changes the object's position if it leaves the screen to make it enter 
	// on the other side
	void ResetPositionOnWraparound()
	{
		if(transform.position.x > stageArea.x)
		{
			transform.position = new Vector2(-stageArea.x, transform.position.y);
		}
		if(transform.position.x < -stageArea.x)
		{
			transform.position = new Vector2(stageArea.x, transform.position.y);
		}
		if(transform.position.y > stageArea.y)
		{
			transform.position = new Vector2(transform.position.x, -stageArea.y);
		}
		if(transform.position.y < -stageArea.y)
		{
			transform.position = new Vector2(transform.position.x, stageArea.y);
		}
	}
}
