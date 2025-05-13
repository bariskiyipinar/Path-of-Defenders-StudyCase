using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private Transform SpawnPoint;
    [SerializeField] private GameObject[] EnemyPrefabList;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private int enemyCountPerWave = 3;

    private int currentWaveIndex = 0;

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        while (currentWaveIndex < EnemyPrefabList.Length)
        {
            GameObject currentEnemyPrefab = EnemyPrefabList[currentWaveIndex];

            for (int i = 0; i < enemyCountPerWave; i++)
            {
                Instantiate(currentEnemyPrefab, SpawnPoint.position, Quaternion.identity);
                yield return new WaitForSeconds(6f); 
            }

            currentWaveIndex++;
            yield return new WaitForSeconds(timeBetweenWaves);
        }

    }


}
