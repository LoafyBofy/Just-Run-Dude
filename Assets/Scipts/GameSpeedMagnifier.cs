using System.Collections;
using UnityEngine;

public class GameSpeedMagnifier : MonoBehaviour
{
    [SerializeField] private int _speedLimit;
    [SerializeField] private int _addedNumber = 10;
    [SerializeField] private int _speedIncreaseTransition = 10;

    private void Start()
    {
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        while (Mover.Speed < _speedLimit)
        {
            yield return new WaitForSeconds(_speedIncreaseTransition);
            IncreaseSpeed();
        }
    }

    private void IncreaseSpeed()
    {
        Mover.Speed += _addedNumber;
    }
}
