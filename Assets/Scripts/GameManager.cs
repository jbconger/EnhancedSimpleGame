using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField]
	Ball ball;
	[SerializeField]
	Paddle playerPaddle;
	[SerializeField]
	Paddle aiPaddle;
	[SerializeField]
	TMPro.TextMeshProUGUI playerScoreText;
	[SerializeField]
	TMPro.TextMeshProUGUI aiScoreText;

	private int _playerScore = 0;
	private int _aiScore = 0;

	public void PlayerScores()
	{
		_playerScore++;
		playerScoreText.text = _playerScore.ToString();
		ResetRound();
	}

	public void AIScores()
	{
		_aiScore++;
		aiScoreText.text = _aiScore.ToString();
		ResetRound();
	}

	private void ResetRound()
	{
		playerPaddle.ResetPosition();
		aiPaddle.ResetPosition();
		ball.ResetPosition();
		ball.AddStartForce();
	}
}
