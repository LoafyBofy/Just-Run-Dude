using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovements : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    [SerializeField] private GameObject _player;
    [Header("Curves")]
    [SerializeField] private AnimationCurve _jumpCurve;
    [SerializeField] private AnimationCurve _dashCurve;
    [SerializeField] private AnimationCurve _rollCurve;
    [SerializeField] private float _animationDuration;
    [Header("Animator")]
    [SerializeField] private Animator _animator;

    private float currentTime;
    private bool _isJump = false;
    private bool _isDash = false;
    private bool _isRoll = false;

    private void Start()
    {
        _animator = _player.GetComponent<Animator>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y)) // Horizontal
        {
            if (eventData.delta.x > 0) // right
            {
                Dash();
                _animator.SetBool("isRun", false);
                _animator.SetBool("isJump", true);
            }
            //else // left
            //{

            //}
        }
        else // Vertical
        {
            if (eventData.delta.y > 0) // up
            {
                Jump();
                _animator.SetBool("isRun", false);
                _animator.SetBool("isJump", true);
            }
            else // down
            {
                Roll();
                _animator.SetBool("isRun", false);
                _animator.SetBool("isRoll", true);
            }
        }
    }

    private void Update()
    {
        InputController();
        CheckCurrentState();
        CheckCurrentTime();
    }

    private void InputController()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
            _animator.SetBool("isRun", false);
            _animator.SetBool("isJump", true);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Dash();
            _animator.SetBool("isRun", false);
            _animator.SetBool("isJump", true);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Roll();
            _animator.SetBool("isRun", false);
            _animator.SetBool("isRoll", true);
        }
    }

    private void CheckCurrentState()
    {
        if (_isJump == true)
        {
            currentTime += Time.deltaTime;
            _player.transform.position = new Vector2(_player.transform.position.x, _jumpCurve.Evaluate(currentTime));
        }
        if (_isDash == true)
        {
            currentTime += Time.deltaTime;
            _player.transform.position = new Vector2(_player.transform.position.x, _dashCurve.Evaluate(currentTime));
        }
        if (_isRoll == true)
        {
            currentTime += Time.deltaTime;
            _player.transform.position = new Vector2(_player.transform.position.x, _rollCurve.Evaluate(currentTime));
        }
    }

    private void CheckCurrentTime()
    {
        if (currentTime >= _animationDuration)
        {
            currentTime = 0;
            _isJump = false;
            _isDash = false;
            _isRoll = false;
            SetRunAnimation();
        }
    }

    private void SetRunAnimation()
    {
        _animator.SetBool("isJump", false);
        _animator.SetBool("isRoll", false);
        _animator.SetBool("isRun", true);
    }

    public void Jump()
    {
        if (_isJump == false && _isDash == false && _isRoll == false)
        {
            _isJump = true;
        }
    }

    public void Dash()
    {
        if (_isJump == false && _isDash == false && _isRoll == false)
        {
            _isDash = true;
        }
    }

    public void Roll()
    {
        if (_isJump == false && _isDash == false && _isRoll == false)
        {
            _isRoll = true;
        }
    }

    public void OnDrag(PointerEventData eventData) // оно просто существует, так нада!
    {
    }
}



