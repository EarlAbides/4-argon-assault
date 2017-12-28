using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
	#region Member Variables

    int score = 0;
    Text scoreText;

	#endregion
	
	#region Unity Hooks

    void Start()
    {
        scoreText = gameObject.GetComponent<Text>();
        scoreText.text = score.ToString();
    }

	#endregion

	#region Public Methods

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

	#endregion
}
