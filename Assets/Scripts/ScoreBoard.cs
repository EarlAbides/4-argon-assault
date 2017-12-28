using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    int score = 0;
    Text scoreText;

    // Use this for initialization
    void Start()
    {
        scoreText = gameObject.GetComponent<Text>();
        scoreText.text = score.ToString();
    }

	public void ScoreHit(int points)
	{
		score += points;
		scoreText.text = score.ToString();
	}

	public void ScorePoints(int points)
	{
		score += points;
		scoreText.text = score.ToString();
	}
}
