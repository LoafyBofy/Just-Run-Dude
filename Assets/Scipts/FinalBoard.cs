using UnityEngine;
using UnityEngine.UI;

public class FinalBoard : MonoBehaviour
{
    [SerializeField] private GameObject _finalBoard;
    [SerializeField] private Text _finalScore;
    static private bool _isGameOnPause = false;

    static public bool IsGameOnPause
    {
        get { return _isGameOnPause; }
        set { _isGameOnPause = value; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Barrier")
        {
            _isGameOnPause = true;
            CheckGameOnPause();
        }
    }

    private void CheckGameOnPause()
    {
        if (_isGameOnPause == true)
        {
            Time.timeScale = 0;
            EnableBoard();
        }
    }

    private void EnableBoard()
    {
        _finalBoard.SetActive(true);
        _finalScore.text = Mathf.Round(Score.CurrentScore).ToString();
    }
}
