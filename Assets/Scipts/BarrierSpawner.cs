using System.Collections;
using UnityEngine;

public class BarrierSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _barriers;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private float _startPositionX;

    private void Start()
    {
        StartCoroutine(SpawnObject());
    }

    private IEnumerator SpawnObject()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnDelay);
            int _randomValue = Random.Range(0, _barriers.Length);
            if (_barriers[_randomValue].activeSelf == false)
            {
                _barriers[_randomValue].gameObject.SetActive(true);
                for (int i = 0; i < _barriers[_randomValue].transform.childCount; i++)
                {
                    Transform child = _barriers[_randomValue].transform.GetChild(i);
                    child.gameObject.SetActive(true);
                }
                _barriers[_randomValue].transform.position = new Vector2(_startPositionX, _barriers[_randomValue].transform.position.y);
            }
        }
    }
}
