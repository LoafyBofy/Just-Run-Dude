using UnityEngine;

public class RotationObject : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;

    private void Update()
    {
        transform.Rotate(0, 0, _rotateSpeed);
    }
}
