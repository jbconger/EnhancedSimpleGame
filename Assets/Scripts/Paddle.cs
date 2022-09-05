using UnityEngine;

public class Paddle : MonoBehaviour
{
	[SerializeField]
	public float _moveSpeed = 10.0f;

	protected Rigidbody2D _rigidbody2D;

	private void Awake()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
	}
}
