using UnityEngine;
using System.Collections;

public class AsteroidPlayerShip : MonoBehaviour
{
	public float rotationPower = 0.1f;
	public float thrustPower = 5;

	public float maxRotationSpeed = 10;
	public float maxTravelSpeed = 10;

	public bool allowBackwardsThrust = true;

	void FixedUpdate()
	{
		// ROTATION
		if(rigidbody2D.angularVelocity < maxRotationSpeed && Input.GetAxis("Horizontal") < 0)
		{
			rigidbody2D.AddTorque(-Input.GetAxis("Horizontal") * rotationPower);
		}
		if(rigidbody2D.angularVelocity > -maxRotationSpeed && Input.GetAxis("Horizontal") > 0)
		{
			rigidbody2D.AddTorque(-Input.GetAxis("Horizontal") * rotationPower);
		}
		// If rotation speed is higher than what we have defined maxRotationSpeed to be
		if(rigidbody2D.angularVelocity > maxRotationSpeed)
		{ // ... then set the current rotation (angularVelocity) to be the same as maxRotationSpeed
			rigidbody2D.angularVelocity = maxRotationSpeed;
		}
		if(rigidbody2D.angularVelocity < -maxRotationSpeed)
		{
			rigidbody2D.angularVelocity = -maxRotationSpeed;
		}

		// THRUST
		// If the traveling speed (velocity.magnitude) is less than our maxTravelSpeed
		if(rigidbody2D.velocity.magnitude <= maxTravelSpeed)
		{ // ... then allow for more thrust to be applied
			if (allowBackwardsThrust)
			{
				rigidbody2D.AddForce(transform.up * thrustPower * Input.GetAxis("Vertical"));
			}
			else
			{
				rigidbody2D.AddForce(transform.up * thrustPower * Mathf.Max(Input.GetAxis("Vertical"), 0));
			}
		}
		// Cap velocity at maxTravelSpeed
		if(rigidbody2D.velocity.magnitude > maxTravelSpeed) // If travel speed to high
		{ // ... then set it to be what we have defined as our maxForwardSpeed
			rigidbody2D.velocity = rigidbody2D.velocity.normalized * maxTravelSpeed;
		}
	}
}
