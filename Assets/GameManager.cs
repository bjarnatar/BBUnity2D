using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	public float levelSpeed = 3.0f;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		levelSpeed += Time.deltaTime;
	}
}
