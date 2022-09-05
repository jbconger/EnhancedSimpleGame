using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField]
	Ball ball;

	private int _playerScore;
	private int _AIScore;

	public void PlayerScores()
	{
		_playerScore++;
		ball.ResetPosition();
	}

	public void AIScores()
	{
		_AIScore++;
		ball.ResetPosition();
	}
}
