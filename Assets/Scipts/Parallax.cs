using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private GameObject _lastObject;
    [SerializeField] private float _step;
    [SerializeField] private float _decreaseSpeed;
    [Header("Layers (1-2)")]
    [SerializeField] private int _layer = 1;
    [Header("Coordinates")]
    [SerializeField] private float _triggerCoordinates;

    static private float _speed = 350;
    Rigidbody2D _rg;

    static public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    private void Start()
    {
        _rg = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_layer == 1)
            _rg.velocity = new Vector2(-(_speed - _decreaseSpeed * 2) * Time.fixedDeltaTime, 0);
        else if (_layer == 2)
            _rg.velocity = new Vector2(-(_speed - _decreaseSpeed) * Time.fixedDeltaTime, 0);
        else
            _rg.velocity = new Vector2(-_speed * Time.fixedDeltaTime, 0);
    }

    private void Update()
    {
        


        if (transform.position.x < _triggerCoordinates)
            transform.position = new Vector2(_lastObject.transform.position.x + _step, transform.position.y);
    }
}

//if (_layer == 1)
//    transform.Translate(new Vector2(-(_speed - _decreaseSpeed * 2) * Time.deltaTime, 0));
//else if (_layer == 2)
//    transform.Translate(new Vector2(-(_speed - _decreaseSpeed) * Time.deltaTime, 0));
//else
//    transform.Translate(new Vector2(-_speed * Time.deltaTime, 0));


//if (transform.position.x < _triggerCoordinates)
//    transform.position = new Vector2(_lastObject.transform.position.x + _step, transform.position.y);
