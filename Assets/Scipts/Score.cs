using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private float _csoreMltiplier = 1.5f;

    static private float _currentScore = 0;
    static private float _multiplier;

    static public float CurrentScore
    {
        get { return _currentScore; }
        set { _currentScore = value; }
    }

    static public float Multiplier
    {
        get { return _multiplier; }
        set { _multiplier = value; }
    }

    private void Start()
    {
        _multiplier = _csoreMltiplier;
    }

    private void Update()
    {
        _currentScore += Time.deltaTime * _multiplier;
        _scoreText.text = Mathf.Round(_currentScore).ToString();
    }
}
