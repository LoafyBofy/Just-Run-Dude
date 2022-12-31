using UnityEngine.UI;
using UnityEngine;

public class Pumpkin : MonoBehaviour
{
    [SerializeField] private Text _pumpkinCountText;
    static private int _pumpkinCount = 0;

    static public int PumpkinCount
    {
        get { return _pumpkinCount; }
        set { _pumpkinCount = value; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pumpkin")
        {
            _pumpkinCount++;
            ChangeText();
            collision.gameObject.SetActive(false);
        }
    }

    private void ChangeText()
    {
        _pumpkinCountText.text = _pumpkinCount.ToString();
    }
}
