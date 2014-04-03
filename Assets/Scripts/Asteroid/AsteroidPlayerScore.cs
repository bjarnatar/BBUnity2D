using UnityEngine;
using System.Collections;

public class AsteroidPlayerScore : MonoBehaviour
{
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
	{
		score += sc;
		scoreText.text = "Score: " + score;
	}
}
