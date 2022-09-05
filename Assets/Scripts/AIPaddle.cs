using System.Collections;
using System.Collections.Generic;
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
			if (ball.velocity.y > this.transform.position.y)
			{
				_rigidbody2D.AddForce(Vector2.up * _moveSpeed);
			} else if (ball.velocity.y < this.transform.position.y)
			{
				_rigidbody2D.AddForce(Vector2.down * _moveSpeed);
			}
		}
		//ball moving away from AI paddle, move towards center
		else
		{
			if(this.transform.position.y > 0.0f)
			{
				_rigidbody2D.AddForce(Vector2.down * _moveSpeed);
			}
			else if (this.transform.position.y < 0.0f)
			{
				_rigidbody2D.AddForce(Vector2.up * _moveSpeed);
			}
		}
	}
}
