using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
	private Rigidbody2D _rigidbody2D;
	private float _moveSpeed = 700.0f;
	private float _lifetime = 3.0f;

	private void Awake()
	{
		_rigidbody2D = this.GetComponent<Rigidbody2D>();
		_rigidbody2D.AddForce(Vector2.right * _moveSpeed);
		Destroy(this.gameObject, _lifetime);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Ball ball = collision.gameObject.GetComponent<Ball>();

		if (ball != null)
		{
			Vector2 normal = collision.GetContact(0).normal;
			ball.AddForce(-normal * 1.5f);
		}

		//Destroy(this.gameObject);
	}
}
