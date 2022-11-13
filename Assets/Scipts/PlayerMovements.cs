using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [Header("Size")]
    [SerializeField] private float _littleSizeX;
    [SerializeField] private float _littleSizeY;
    [SerializeField] private float _normalSizeX;
    [SerializeField] private float _normalSizeY;

    [Header("Curves")]
    [SerializeField] private AnimationCurve _jumpCurve;
    [SerializeField] private AnimationCurve _dashCurve;
    [SerializeField] private AnimationCurve _rollCurve;

    private float currentTime;
    private bool _isJump = false;
    private bool _isDash = false;
    private bool _isRoll = false;
    
    private void Update()
    {
        CheckCurrentState();
        CheckCurrentTime();

        if (Input.touchCount > 0)
            Swipe();

        // Нужно чисто для теста (удалить при финальной сборке!)
        if (Input.GetKeyDown(KeyCode.UpArrow))
            Jump();
        if (Input.GetKeyDown(KeyCode.RightArrow))
            Dash();
        if (Input.GetKeyDown(KeyCode.DownArrow))
            Roll();
    }

    private void Swipe()
    {
        Vector2 delta = Input.GetTouch(0).deltaPosition;

        if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y)) // Horizontal
        {
            if (delta.x > 0) // right
            {
                Dash();
            }
            //else // left
            //{

            //}
        }
        else // Vertical
        {
            if (delta.y > 0) // up
            {
                Jump();
            }
            else // down
            {
                Roll();
            }
        }
    }

    private void CheckCurrentState()
    {
        if (_isJump == true)
        {
            currentTime += Time.deltaTime;
            transform.position = new Vector2(transform.position.x, _jumpCurve.Evaluate(currentTime));
        }
        if (_isDash == true)
        {
            currentTime += Time.deltaTime;
            transform.position = new Vector2(transform.position.x, _dashCurve.Evaluate(currentTime));
        }
        if (_isRoll == true)
        {
            currentTime += Time.deltaTime;
            transform.position = new Vector2(transform.position.x, _rollCurve.Evaluate(currentTime));
        }
    }

    private void CheckCurrentTime()
    {
        if (currentTime >= 1)
        {
            currentTime = 0;
            _isJump = false;
            _isDash = false;
            _isRoll = false;
            SetNormalScale();
        }
    }

    public void Jump()
    {
        if (_isJump == false && _isDash == false && _isRoll == false)
        {
            _isJump = true;
            SetLittleScale();
        }
    }

    public void Dash()
    {
        if (_isJump == false && _isDash == false && _isRoll == false)
        {
            _isDash = true;
            SetLittleScale();
        }
    }

    public void Roll()
    {
        if (_isJump == false && _isDash == false && _isRoll == false)
        {
            _isRoll = true;
            SetLittleScale();
        }
    }

    private void SetLittleScale() => transform.localScale = new Vector2(_littleSizeX, _littleSizeY);

    private void SetNormalScale() => transform.localScale = new Vector2(_normalSizeX, _normalSizeY);
}



