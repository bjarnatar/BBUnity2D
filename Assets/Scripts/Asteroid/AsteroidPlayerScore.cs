using UnityEngine;
using System.Collections;

public class AsteroidPlayerScore : MonoBehaviour
{
	public float speedMultiplier = 1f;
	public TextMesh scoreText;
	public TextMesh highScoreText;

	private int score = 0;
	
	void Awake()
	{
		scoreText.text = "Score: 0";
		highScoreText.text = "Highscore: " + PlayerPrefs.GetInt ("HighScore", 0);
	}
	
	public void UpdateHighScoreOnDeath()
	{
		int savedHighScore = PlayerPrefs.GetInt("HighScore", 0);
		if (score > savedHighScore)
		{
			PlayerPrefs.SetInt("HighScore", score);
		}
	}

	public void AddScore(int sc)
	{ // More score when flying faster!!!
		int speedMultipliedScore = Mathf.FloorToInt((float)sc * speedMultiplier * rigidbody2D.velocity.magnitude);

		score += speedMultipliedScore;
		scoreText.text = "Score: " + score;
	}
}
