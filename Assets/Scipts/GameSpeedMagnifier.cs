using System.Collections;
using UnityEngine;

public class GameSpeedMagnifier : MonoBehaviour
{
    [SerializeField] private float _speedLimit;
    [SerializeField] private float _addedNumber;
    [SerializeField] private float _speedIncreaseTransition;

    private void Start()
    {
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        while (ObjectMover.Speed < _speedLimit)
        {
            yield return new WaitForSeconds(_speedIncreaseTransition);
            IncreaseSpeed();
        }
    }

    private void IncreaseSpeed()
    {
        ObjectMover.Speed += _addedNumber;
    }
}
