using UnityEngine.UI;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] private Text _coinsText;
    static private int _coinsCount = 0;

    static public int CoinsCount
    {
        get { return _coinsCount; }
        set { _coinsCount = value; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            _coinsCount++;
            ChangeText();
            collision.gameObject.SetActive(false);
        }
    }

    private void ChangeText()
    {
        _coinsText.text = _coinsCount.ToString();
    }
}
