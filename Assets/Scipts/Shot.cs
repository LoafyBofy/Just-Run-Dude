using UnityEngine;
using UnityEngine.UI;
using System;

public class Shot : MonoBehaviour
{
    [SerializeField] private GameObject _magicBallPrefab;
    [SerializeField] private Image _image;
    [SerializeField] private Text _textCD;
    [SerializeField] private float _CD;
    private float _currentCD;
    private bool _isReady = true;

    private void Start()
    {
        _currentCD = _CD;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isReady == true)
            SpawnMagicBall();

        if (_isReady == false)
            CountDown();
    }

    private void SpawnMagicBall()
    {
        Instantiate(_magicBallPrefab, gameObject.transform.position, Quaternion.identity);
        _isReady = false;
        ChangeColor();
    }

    private void CountDown()
    {
        _currentCD -= Time.deltaTime;
        SetText();
        if (_currentCD <= 0)
        {
            _isReady = true;
            _currentCD = _CD;
            _textCD.text = "";
            ChangeColor();
        }
    }

    private void ChangeColor()
    {
        if (_isReady == true)
            _image.color = new Color(1, 1, 1);
        else
            _image.color = new Color(0.5f, 0.5f, 0.5f);
    }

    private void SetText() => _textCD.text = Math.Round(_currentCD, 2).ToString();
}
