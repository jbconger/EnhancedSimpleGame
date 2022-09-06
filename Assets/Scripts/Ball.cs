using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
	[SerializeField]
	float moveSpeed = 200.0f;
	[SerializeField]
	AudioClip bounceSound;
	[SerializeField]
	AudioClip scoreSound;

	private Rigidbody2D _rigidbody2D;
	private AudioSource _audioSource;

	private void Awake()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
		_audioSource = GetComponent<AudioSource>();
	}

	private void Start()
	{
		ResetPosition();
		StartCoroutine(WaitToAddForce());
	}

	public void ResetPosition()
	{
		_rigidbody2D.position = Vector3.zero;
		_rigidbody2D.velocity = Vector3.zero;
	}

	public void AddStartForce()
	{
		//get horizontal ball direction
		float x = Random.value < 0.5f ? -1.0f : 1.0f;
		//get ball angle
		float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);

		Vector2 direction = new Vector2(x, y);
		_rigidbody2D.AddForce( direction * moveSpeed);
	}

	public void AddForce(Vector2 force)
	{
		_rigidbody2D.AddForce(force);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		GameObject impactObject = collision.gameObject;

		if (impactObject.tag == "ScoreZone")
			_audioSource.clip = scoreSound;
		else
			_audioSource.clip = bounceSound;

		if (impactObject.tag == "Laser")
			Destroy(impactObject);

		_audioSource.Play();
	}

	IEnumerator WaitToAddForce()
	{
		yield return new WaitForSeconds(1.0f);
		AddStartForce();
	}
}
