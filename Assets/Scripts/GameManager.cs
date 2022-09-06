using System.Collections;
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
	[SerializeField]
	GameObject gameOverScreen;

	private int _playerScore = 0;
	private int _aiScore = 0;
	private float _waitTime = 1.0f;
	private int _maxScore = 5;

	public void PlayerScores()
	{
		_playerScore++;
		playerScoreText.text = _playerScore.ToString();

		if (_playerScore >= _maxScore)
		{
			RoundOver();
			return;
		}

		ResetRound();
	}

	public void AIScores()
	{
		_aiScore++;
		aiScoreText.text = _aiScore.ToString();

		if (_aiScore >= _maxScore)
		{
			RoundOver();
			return;
		}

		ResetRound();
	}

	private void ResetRound()
	{
		playerPaddle.ResetPosition();
		aiPaddle.ResetPosition();
		ball.ResetPosition();
		StartCoroutine(Wait());
	}

	private void RoundOver()
	{
		Destroy(ball.gameObject);
		Destroy(playerPaddle.gameObject);
		Destroy(aiPaddle.gameObject);
		gameOverScreen.SetActive(true);
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(_waitTime);
		ball.AddStartForce();
	}
}
