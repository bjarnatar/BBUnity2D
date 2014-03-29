using UnityEngine;
using System.Collections;

public class AsteroidResetPosition : MonoBehaviour
{
	private Vector2 stageArea = new Vector2(7.5f, 5.5f);

	void Update ()
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
