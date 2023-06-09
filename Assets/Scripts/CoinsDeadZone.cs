using UnityEngine;
using UnityEngine.Events;

public class CoinsDeadZone : MonoBehaviour
{
	[SerializeField] private Spawner _spawner;

	public event UnityAction CoinsCollected;

	private int _targetCoinsCount;
	private int _currentCoinsCount;

	private void Start()
	{
		_currentCoinsCount = 0;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		collision.gameObject.SetActive(false);
		_currentCoinsCount++;
		if (_currentCoinsCount == _targetCoinsCount)
			CoinsCollected?.Invoke();
	}

	public void SetTargetCoinsCount(int count)
	{
		_targetCoinsCount = count;
	}
}
