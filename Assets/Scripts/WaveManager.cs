using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private Transform SpawnPoint;
    [SerializeField] private GameObject[] EnemyPrefabList;
    [SerializeField] private float timeBetweenWaves = 20f;
    [SerializeField] private int enemyCountPerWave = 3;
    [SerializeField] private GameObject FinishEffect;
     
    private int currentWaveIndex = 0;

    private void Start()
    {
        StartCoroutine(SpawnWaves());
        FinishEffect.SetActive(false);
    }

    private IEnumerator SpawnWaves()
    {
        while (currentWaveIndex < EnemyPrefabList.Length)
        {
            GameObject currentEnemyPrefab = EnemyPrefabList[currentWaveIndex];

            for (int i = 0; i < enemyCountPerWave; i++)
            {
                Instantiate(currentEnemyPrefab, SpawnPoint.position, Quaternion.Euler(0, 180f, 0));
                yield return new WaitForSeconds(10f);
            }

            enemyCountPerWave++;
            currentWaveIndex++;

            float waitTimer = 0f;
            float waitTime = timeBetweenWaves;
            bool spacePressed = false;

            while (waitTimer < waitTime)
            {
                if (Input.GetKeyDown(KeyCode.Space) && !spacePressed)
                {
                    waitTime = Mathf.Max(0f, waitTime - 5f);
                    spacePressed = true;
                }

                waitTimer += Time.deltaTime;
                yield return null;
            }
        }

    
        while (GameObject.FindObjectsOfType<EnemyAttack>().Length > 0)
        {
            yield return null;
        }

        FinishEffect.SetActive(true);

        ParticleSystem ps = FinishEffect.GetComponent<ParticleSystem>();
        if (ps != null) ps.Play();

        yield return new WaitForSeconds(5f);

      
        SceneManager.LoadScene("Menu");
    }






}
