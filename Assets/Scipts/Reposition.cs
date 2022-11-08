using UnityEngine;

public class Reposition : MonoBehaviour
{
    [SerializeField] private float _newCoordinateX = 60.0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.position = new Vector2(_newCoordinateX, collision.transform.position.y);
    }
}
