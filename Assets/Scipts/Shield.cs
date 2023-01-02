using UnityEngine;

public class Shield : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MagicBarrier")
        {
            collision.gameObject.SetActive(false);
        }
    }
}
