using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private int _objectCount;

    private List<GameObject> _coinsList = new List<GameObject>();

	private void Start()
	{
        InstantiateObjects(_objectCount);
	}

	private void InstantiateObjects(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var obj = Instantiate(_coinPrefab);
            obj.SetActive(false);
            _coinsList.Add(obj);
        }
    }

	private GameObject InstantiateNewObject()
	{
		var obj = Instantiate(_coinPrefab);
		obj.SetActive(false);
		_coinsList.Add(obj);
        return obj;
	}

	public GameObject GetObject()
    {
        for (int i = 0; i < _coinsList.Count; i++)
        {
            if (_coinsList[i].activeSelf == false)
            {
                return _coinsList[i];
            }
        }
        return InstantiateNewObject();
    }
}
