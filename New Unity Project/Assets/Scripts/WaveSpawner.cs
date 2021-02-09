using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    //enemy prefab
    public Transform enemy;

    //reference for spawn point
    public Transform spawnPoint;

    //timer for save to spawn
    public float waveSpawnTime = 5f;

    //timer for the firstwave to spawn
    private float countdown = 2f;

    //reference for countdown text
    public Text waveCountdownText;

    public int waveIndex = 0;


    private void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = waveSpawnTime;

        }

        countdown -= Time.deltaTime;
        waveCountdownText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);

        }

        
    }

    private void SpawnEnemy()
    {
        Instantiate(enemy,spawnPoint.position, spawnPoint.rotation);
    }
}
