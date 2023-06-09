using UnityEngine;

public class Coin : MonoBehaviour
{
	[SerializeField] private float _speed;

    private SpriteRenderer _spriteRenderer;
	private Rigidbody2D _rigidBody;
	private Transform _transform;

	private void Awake()
	{
		_spriteRenderer = GetComponent<SpriteRenderer>();
		_transform = GetComponent<Transform>();
		_rigidBody = GetComponent<Rigidbody2D>();
	}

	public void SetCoinParameters(CoinSO coinSO, Vector3 spawnPoint)
	{
		_spriteRenderer.sprite = coinSO.Sprite;
		_transform.localScale = coinSO.Scale;
		_transform.position = spawnPoint;
	}

	private void FixedUpdate()
	{
		_rigidBody.velocity = new Vector2(0, -_speed);
	}
}
