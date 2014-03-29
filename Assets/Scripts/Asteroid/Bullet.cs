using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	public float timeToLive = 2;

	// Use this for initialization
	void Start ()
	{
		Object.Destroy (gameObject, timeToLive);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
