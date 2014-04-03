using UnityEngine;
using System.Collections;

public class AsteroidPlayerShip : MonoBehaviour
{
	public float rotationPower = 0.1f;
	public float thrustPower = 5;

	public float maxRotationSpeed = 10;
	public float maxTravelSpeed = 10;

	public bool allowBackwardsThrust = true;

	public Rigidbody2D bulletPrefab;
	public float bulletSpeed = 20;

	public AudioSource deathSound;

	private bool isDead = false;

	void Update()
	{
		if (!isDead)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				Rigidbody2D bulletInstance = (Rigidbody2D) Instantiate (bulletPrefab, transform.position, transform.rotation);
				bulletInstance.velocity = transform.rotation * Vector2.up * bulletSpeed;
			}
		}
	}

	void FixedUpdate()
	{
		if (!isDead)
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
		}
		// Cap velocity at maxTravelSpeed
		if(rigidbody2D.velocity.magnitude > maxTravelSpeed) // If travel speed to high
		{ // ... then set it to be what we have defined as our maxForwardSpeed
			rigidbody2D.velocity = rigidbody2D.velocity.normalized * maxTravelSpeed;
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Asteroid")
		{ // Die!
			// Update high score
			AsteroidPlayerScore aps = GetComponent<AsteroidPlayerScore>();
			aps.UpdateHighScoreOnDeath();

			Instantiate(deathSound);

			// Tell the game manager the player is dead
			AsteroidGameManager agm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<AsteroidGameManager>();
			agm.PlayerDied();

			// Disable Inputs
			isDead = true;
		}
	}
}
