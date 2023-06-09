using UnityEngine;
using DG.Tweening;

public class Shaker : MonoBehaviour
{
	[SerializeField] private CoinsDeadZone _deadZone;
	[SerializeField] private float _shakeStrength;
	[SerializeField] private int _shakeVibrato;
	[SerializeField] private float _shakeDuration;
	[SerializeField] private AudioSource _shakeSoundSource;

	private void OnEnable()
	{
		_deadZone.CoinsCollected += ShakeIt;
	}

	private void OnDisable()
	{
		_deadZone.CoinsCollected -= ShakeIt;
	}

	private void ShakeIt()
	{
		Tweener tweener = transform.DOShakePosition(_shakeDuration, strength: _shakeStrength, vibrato: _shakeVibrato);
		_shakeSoundSource.Play();
	}
}
