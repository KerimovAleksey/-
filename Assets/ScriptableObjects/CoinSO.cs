using UnityEngine;

[CreateAssetMenu(fileName = "New Coin", menuName = "Coins/New Coin", order = 51)]
public class CoinSO : ScriptableObject
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Vector3 _scale;
    [SerializeField] private string _name;

    public Sprite Sprite => _sprite;
    public Vector3 Scale => _scale;
    public string Name => _name;
}
