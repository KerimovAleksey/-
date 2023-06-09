using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
	[SerializeField] private TMP_Text _domovoiLabel;
	[SerializeField] private GameObject _buttonsContainer;
	[SerializeField] private DomovoiController _domovoi;
	[SerializeField] private Button _restartButton;

	private string _correctSequence = "";
	private string _inputSequence = "";
	private int _responseAttempts = 0;
	private int _coinsCount;

	private void OnEnable()
	{
		_spawner.SpawnIsEnd += SaveAnswerSequence;
	}

	private void OnDisable()
	{
		_spawner.SpawnIsEnd -= SaveAnswerSequence;
	}

	private void SaveAnswerSequence(string sequence, int coinsCount)
	{
		_correctSequence = sequence;
		_coinsCount = coinsCount;
		Invoke(nameof(StartGetAnswerStep), 4f); // задерка до по€влени€ кнопок, что бы все монеты упали
	}

	private void StartGetAnswerStep()
	{
		_inputSequence = "";
		ChangeCanvasElementsEnabled();
		SetLabelText(_domovoi.GetPhrase("choose"));
	}

	private void StartSpawningStep()
	{
		ChangeCanvasElementsEnabled();
		_spawner.StartSpawning();
	}

	private void ChangeCanvasElementsEnabled()
	{
		_domovoiLabel.gameObject.SetActive(!_domovoiLabel.gameObject.activeSelf);
		_buttonsContainer.SetActive(!_buttonsContainer.activeSelf);
	}

	public void GetAnswer(string coinValue)
	{
		_inputSequence += coinValue;
		_responseAttempts++;
		if (_responseAttempts == _coinsCount) // ѕроверка итога, когда кол-во попыток вводу =  ол-ву упавших монет
		{
			if (_inputSequence == _correctSequence)
			{
				_domovoi.SetAnimation("win");
				SetWin();
			}
			else
			{
				_domovoi.SetAnimation("wrong");
				SetLose();
			}
			_restartButton.gameObject.SetActive(true);
		}
	}

	private void SetLabelText(string text)
	{
		_domovoiLabel.text = text;
	}

	private void SetWin()
	{
		SetLabelText(_domovoi.GetPhrase("correct"));
	}

	private void SetLose()
	{
		SetLabelText(_domovoi.GetPhrase("incorrect"));
	}

	public void ReloadGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
