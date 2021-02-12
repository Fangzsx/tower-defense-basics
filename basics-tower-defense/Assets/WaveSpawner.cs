using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    //object to spawn
    public Transform enemyPrefab;

    //time between each wave to spawn
    private float timeBetweenSpawn = 5f;

    //countdown for wave to spawn
    private float countdown = 0f;

    //number of enemies to spawn per wave
    private int waveIndex = 0;

    //spawn location
    public Transform spawnPoint;

    public Text countdownTimer;

    private void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenSpawn;
        }

        //decrease the countdown by 1 per frame
        countdown -= Time.deltaTime;

        countdownTimer.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;

        //iterate over the waveNumberIndex
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }


}
