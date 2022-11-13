using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    static private float _speed = 5;

    static public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    private void Update()
    {
        transform.Translate(new Vector2(-_speed * Time.deltaTime, 0));
    }
}

