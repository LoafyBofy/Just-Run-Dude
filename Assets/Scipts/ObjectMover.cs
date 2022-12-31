using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    static private float _speed = 350;

    static public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    Rigidbody2D rg;
    private void Start()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rg.velocity = new Vector2(-_speed * Time.fixedDeltaTime, 0);
    }

    //private void Update()
    //{
    //    transform.Translate(new Vector2(-_speed * Time.deltaTime, 0));
    //}
}

