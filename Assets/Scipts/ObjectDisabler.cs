using UnityEngine;

public class ObjectDisabler : MonoBehaviour
{
    [SerializeField] private float _newCoordinateX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.position = new Vector2(_newCoordinateX, collision.transform.position.y);
        collision.gameObject.SetActive(false);
    }
}