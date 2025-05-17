using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private Transform SpawnPoint;
    [SerializeField] private GameObject[] EnemyPrefabList;
    [SerializeField] private float timeBetweenWaves = 20f;
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
                Instantiate(currentEnemyPrefab, SpawnPoint.position, Quaternion.Euler(0,180f,0));
                yield return new WaitForSeconds(10f);
               
            }
            enemyCountPerWave++;
            currentWaveIndex++;

            if(Input.GetKeyDown(KeyCode.Space)) {
                yield return new WaitForSeconds(timeBetweenWaves-5f);
            }
            yield return new WaitForSeconds(timeBetweenWaves);

          
        }

    }




}
