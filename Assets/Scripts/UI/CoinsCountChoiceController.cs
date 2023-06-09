using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinsCountChoiceController : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinsCountLabel;
    [SerializeField] private Slider _slider;

	private void Awake()
	{
		_slider.value = PlayerPrefs.GetInt("CoinsCount", 5);
	}

	public void SetCountOfCoins()
    {
        float newValue = _slider.value;
		_coinsCountLabel.text = newValue.ToString();
        PlayerPrefs.SetInt("CoinsCount", (int)newValue);
    }
}
