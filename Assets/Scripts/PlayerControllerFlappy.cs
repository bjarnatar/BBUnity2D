using UnityEngine;
using System.Collections;

public class PlayerControllerFlappy : MonoBehaviour
{
	public float jumpForce = 5;

	void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			rigidbody2D.velocity = Vector2.up * jumpForce;
		}
	}
}
