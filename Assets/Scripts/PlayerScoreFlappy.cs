using UnityEngine;
using System.Collections;

public class PlayerScoreFlappy : MonoBehaviour
{
	public TextMesh scoreTextMesh;

	private int score = 0;

	void Awake()
	{
		scoreTextMesh.text = "Score: 0";
	}

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		score = score + 1;
		scoreTextMesh.text = "Score: " + score;
	}
}
