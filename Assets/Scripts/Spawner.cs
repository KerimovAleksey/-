using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnDelay;

    [SerializeField] private CoinSO[] _coinsSO;
    [SerializeField] private ObjectPool _objPool;
    [SerializeField] private CoinsDeadZone _deadZone;

    private string _coinSequence;
    private int _coinsWaveCount;

    public event UnityAction<string, int> SpawnIsEnd;

    public void StartSpawning()
    {
        _coinsWaveCount = PlayerPrefs.GetInt("CoinsCount", 4);
        _deadZone.SetTargetCoinsCount(_coinsWaveCount);
        StartCoroutine(SpawnCoins());
    }

	private IEnumerator SpawnCoins()
    {
        int index = -1; // Для отслеживания индексов учитывая выход из диапазона цикла
        _coinSequence = "";
        ShuffleCoinsSOList();
        for (int i = 0; i < _coinsWaveCount; i++)
        {
            index++;
            if (index % _coinsSO.Length == 0 && index != 0) // Если нужно заспавнить больше монет, чем есть их вариантов, что бы волны не были повторяющиеся
            {
				ShuffleCoinsSOList();
                index = 0;
            }

            var coin = _objPool.GetObject();
            coin.SetActive(true);
            coin.GetComponent<Coin>().SetCoinParameters(_coinsSO[index], transform.position);
            _coinSequence += _coinsSO[index].Name; // Сохраняем последовательность монет для последующей проверки ответа
            yield return new WaitForSeconds(_spawnDelay);
        }
        SpawnIsEnd?.Invoke(_coinSequence, _coinsWaveCount);
    }


    // Перемешиваем список монет для рандомности спавна монет
    private void ShuffleCoinsSOList()
    {
        for (int i = _coinsSO.Length - 1; i >= 1; i--)
        {
            int tempIndex = Random.Range(0, _coinsSO.Length - 1);

            var tempElement = _coinsSO[tempIndex];
            _coinsSO[tempIndex] = _coinsSO[i];
            _coinsSO[i] = tempElement;
        }
	}

    public void SetCoinsCount(int count)
    {
        _coinsWaveCount = count;
    }

    public int GetCoinsCount()
    {
        return _coinsWaveCount;
    }
}
