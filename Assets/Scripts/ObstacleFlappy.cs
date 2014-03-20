using UnityEngine;
using System.Collections;

public class ObstacleFlappy : MonoBehaviour
{
	public float verticalMaxStartPosition;
	public float verticalMinStartPosition;
	public float horizontalStartPosition;
	public float horizontalEndPosition;

	private GameManager gm;

	void Start ()
	{
		gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
		Reset( transform.position.x );
	}

	void FixedUpdate ()
	{
		rigidbody2D.velocity = -Vector2.right * gm.levelSpeed;
		if(transform.position.x < horizontalEndPosition)
		{
			Reset( horizontalStartPosition );
		}
	}

	void Reset(float horizontalStartPos)
	{
		float randomVerticalStartPosition = Random.Range(verticalMinStartPosition, verticalMaxStartPosition);
		transform.position = new Vector2(horizontalStartPos, randomVerticalStartPosition);
	}
}
