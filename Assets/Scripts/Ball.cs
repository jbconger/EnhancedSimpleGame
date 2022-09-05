using UnityEngine;

public class Ball : MonoBehaviour
{
	[SerializeField]
	float _moveSpeed = 200.0f;

	private Rigidbody2D _rigidbody2D;

	private void Awake()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
	}

	private void Start()
	{
		ResetPosition();
	}

	public void ResetPosition()
	{
		_rigidbody2D.position = Vector3.zero;
		_rigidbody2D.velocity = Vector3.zero;

		AddStartForce();
	}

	private void AddStartForce()
	{
		//get horizontal ball direction
		float x = Random.value < 0.5f ? -1.0f : 1.0f;
		//get ball angle
		float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);

		Vector2 direction = new Vector2(x, y);
		_rigidbody2D.AddForce( direction * _moveSpeed);
	}

	public void AddForce(Vector2 force)
	{
		_rigidbody2D.AddForce(force);
	}
}
