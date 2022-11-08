using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private int speed = 300;
    static private int _speed;
    private Rigidbody2D _rigidbody2d;

    static public int Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    private void Awake()
    {
        _speed = speed;
    }

    private void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody2d.velocity = new Vector2(-_speed * Time.fixedDeltaTime, 0);
    }
}