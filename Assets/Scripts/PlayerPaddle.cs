using System.Collections;
using UnityEngine;

public class PlayerPaddle : Paddle
{
	[SerializeField]
	GameObject laser;
	[SerializeField]
	float laserCooldown = 2.0f;

	private Vector2 _direction;
	private bool _bLaserReady = true;

	private float _dashingMultiplier = 1.0f;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.LeftAlt))
			_dashingMultiplier = 3.0f;
		else if(Input.GetKeyUp(KeyCode.LeftAlt))
			_dashingMultiplier = 1.0f;

		if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
			_direction = Vector2.up;
		}
		else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
		{
			_direction = Vector2.down;
		}
		else
		{
			_direction = Vector2.zero;
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			LaunchLaser();
		}
	}

	private void FixedUpdate()
	{
		if (_direction.sqrMagnitude != 0)
		{
			_rigidbody2D.AddForce(_direction * _moveSpeed * _dashingMultiplier);
		}
	}

	private void LaunchLaser()
	{
		if (_bLaserReady)
		{
			_bLaserReady = false;
			Instantiate(laser, this.transform.position, Quaternion.Euler(Vector3.zero));
			StartCoroutine(Wait(laserCooldown));
		}

	}

	IEnumerator Wait(float time)
	{
		yield return new WaitForSeconds(time);
		_bLaserReady = true;
	}
}
