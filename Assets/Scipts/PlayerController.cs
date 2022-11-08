using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Coordinates")]
    [SerializeField] private float _runCoordinateY;
    [SerializeField] private float _jumpCoordinateY;
    [SerializeField] private float _dashCoordinateY;
    [SerializeField] private float _rollCoordinateY;

    [Header("CurrentState")]
    [SerializeField] private States _currentState = States.Run;
    [SerializeField] private float _transitionTime;

    [Header("PlayerSize")]
    [SerializeField] private float _sizeX = 0.8f;
    [SerializeField] private float _sizeY = 0.8f;
    [SerializeField] private float _sizeRunY = 1.4f;

    enum States
    {
        Run,
        Jump,
        Dash,
        Roll
    }

    public void SetJumpState()
    {
        _currentState = States.Jump;
        SetCurrentState();
        Invoke("SetRunState", _transitionTime);
    }

    public void SetDashState()
    {
        _currentState = States.Dash;
        SetCurrentState();
        Invoke("SetRunState", _transitionTime);
    }

    public void SetRollState()
    {
        _currentState = States.Roll;
        SetCurrentState();
        Invoke("SetRunState", _transitionTime);
    }

    private void SetRunState()
    {
        _currentState = States.Run;
        SetCurrentState();
    }

    private void SetCurrentState()
    {
        switch (_currentState)
        {
            case States.Run:
                transform.localScale = new Vector2(_sizeX, _sizeRunY);
                transform.position = new Vector2(transform.position.x, _runCoordinateY);
                break;
            case States.Jump:
                transform.localScale = new Vector2(_sizeX, _sizeY);
                transform.position = new Vector2(transform.position.x, _jumpCoordinateY);
                break;
            case States.Dash:
                transform.localScale = new Vector2(_sizeX, _sizeY);
                transform.position = new Vector2(transform.position.x, _dashCoordinateY);
                break;
            case States.Roll:
                transform.localScale = new Vector2(_sizeX, _sizeY);
                transform.position = new Vector2(transform.position.x, _rollCoordinateY);
                break;
        }
    }
}
