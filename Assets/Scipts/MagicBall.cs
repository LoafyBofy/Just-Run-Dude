using UnityEngine;

public class MagicBall : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timeBeforeDestroy;

    private void Start()
    {
        Invoke("SelfDestruct", _timeBeforeDestroy);
    }

    private void Update()
    {
        transform.Translate(new Vector2(_speed * Time.deltaTime, 0));
    }

    private void SelfDestruct() => Destroy(gameObject);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MagicBarrier")
        {
            collision.gameObject.SetActive(false);
            SelfDestruct();
        }
    }
}
