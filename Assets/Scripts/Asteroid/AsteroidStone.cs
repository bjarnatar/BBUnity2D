using UnityEngine;
using System.Collections;

public class AsteroidStone : MonoBehaviour
{
	public float maxStartingVelocity;

	public Rigidbody2D asteroidPrefabNextSizeDown;
	public float newAsteroidVelocity = 0.5f;
	public float asteroidExitAngle = 60.0f;
	public float newAsteroidStartingDistance = 1f;

	public bool isLarge = false;

	// Use this for initialization
	void Start ()
	{
	
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Bullet")
		{
			// Destroy this asteroid and the bullet
			Object.Destroy(gameObject);
			Object.Destroy(other.gameObject);

			if (isLarge)
			{ // Let the game manager know a large asteroid was just destroyed
				AsteroidGameManager agm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<AsteroidGameManager>();
				agm.currentLargeAsteroids--;
			}

			// If there is a prefab for the next size down, create two new asteroids (split in half)
			if (asteroidPrefabNextSizeDown)
			{
				Vector3 instance1Direction = Quaternion.AngleAxis(asteroidExitAngle, Vector3.forward) * other.relativeVelocity.normalized;
				Vector3 instance2Direction = Quaternion.AngleAxis(-asteroidExitAngle, Vector3.forward) * other.relativeVelocity.normalized;

				Vector3 a1StartingPosition = transform.position + instance1Direction * newAsteroidStartingDistance;
				Vector3 a2StartingPosition = transform.position + instance2Direction * newAsteroidStartingDistance;

				Rigidbody2D asteroidInstance1 = (Rigidbody2D) Instantiate(asteroidPrefabNextSizeDown, a1StartingPosition, transform.rotation);
				Rigidbody2D asteroidInstance2 = (Rigidbody2D) Instantiate(asteroidPrefabNextSizeDown, a2StartingPosition, transform.rotation);
	
				asteroidInstance1.velocity = instance1Direction * newAsteroidVelocity;
				asteroidInstance2.velocity = instance2Direction * newAsteroidVelocity;
			}
		}
	}
}
