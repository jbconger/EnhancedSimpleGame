using UnityEngine;

public class AIPaddle : Paddle
{
	[SerializeField]
	Rigidbody2D ball;

	private void FixedUpdate()
	{
		//ball moving towards AI paddle
		if (ball.velocity.x > 0.0f)
		{
			if (ball.position.y > _rigidbody2D.position.y)
			{
				_rigidbody2D.AddForce(Vector2.up * _moveSpeed);
			} else if (ball.position.y < _rigidbody2D.position.y)
			{
				_rigidbody2D.AddForce(Vector2.down * _moveSpeed);
			}
		}
		//ball moving away from AI paddle, move towards center
		else
		{
			if(_rigidbody2D.position.y > 0.0f)
			{
				_rigidbody2D.AddForce(Vector2.down * _moveSpeed);
			}
			else if (_rigidbody2D.position.y < 0.0f)
			{
				_rigidbody2D.AddForce(Vector2.up * _moveSpeed);
			}
		}
	}
}
