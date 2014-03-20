using UnityEngine;
using System.Collections;

public class PlayerScoreFlappy : MonoBehaviour
{
	public TextMesh scoreTextMesh;
	public TextMesh highScoreTextMesh;

	private int score = 0;
	private int highScore = 0;

	void Awake()
	{
		scoreTextMesh.text = "Score: 0";
		highScoreTextMesh.text = "Highscore: " + PlayerPrefs.GetInt ("HighScore", 0);
	}

	public void UpdateHighScoreOnDeath()
	{
		int savedHighScore = PlayerPrefs.GetInt("HighScore", 0);
		if (score > savedHighScore)
		{
			PlayerPrefs.SetInt("HighScore", score);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		score = score + 1;
		scoreTextMesh.text = "Score: " + score;
	}
}
