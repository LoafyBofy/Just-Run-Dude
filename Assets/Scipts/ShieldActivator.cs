using UnityEngine;
using UnityEngine.UI;
using System;

public class ShieldActivator : MonoBehaviour
{
    [SerializeField] private GameObject _shield;
    [SerializeField] private Image _image;
    [SerializeField] private Text _textCD;
    [SerializeField] private float _CD;
    private float _currentCD;
    private bool _isReady = true;
    private bool _isReloading = false;

    private void Start()
    {
        _currentCD = _CD;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && _isReady == true)
            EnableShield();

        if (_isReady == false || _isReloading == true)
            CountDown();

    }

    private void EnableShield()
    {
        _shield.SetActive(true);
        _isReady = false;
    }

    private void CountDown()
    {
        _currentCD -= Time.deltaTime;
        SetText();
        if (_currentCD <= 0 && _isReloading == false)
        {
            _shield.SetActive(false);
            _isReloading = true;
            _currentCD = _CD;
            SetText();
            ChangeColor();
        }
        else if (_currentCD <= 0 && _isReloading == true)
        {
            _isReady = true;
            _isReloading = false;
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
