using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private int _countEnemies;
    [SerializeField] private List<GameObject> prefabs = new();

    void Start()
    {
        for(int i = 0; i < _countEnemies; i++)
        {
            float x = Random.Range(700, 3500);
            float y = Random.Range(-200, 200);
            int k = Random.Range(0, prefabs.Count);
            Instantiate(prefabs[k], new Vector3(x, y), Quaternion.identity);
        }
    }
}
