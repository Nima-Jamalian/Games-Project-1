using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float enemySpawnRate;
    [SerializeField] bool canSpawn = true;
    [SerializeField] GameObject[] powerUpPrefabs;
    [SerializeField] float speedPowerUpSpawnRate;
    GameManager gameManager;
    float worldSizeWidth;
    float worldSizeHeight;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        worldSizeWidth = gameManager.worldSizeWidth;
        worldSizeHeight = gameManager.worldSizeHight;
        StartCoroutine(SpawnEnemey());
        StartCoroutine(SpawnPowerUp());
    }

    // Update is called once per frame
    void Update()
    {


    }

    IEnumerator SpawnEnemey()
    {
        while (canSpawn == true)
        {
            Instantiate(enemyPrefab, new Vector3(Random.Range(-worldSizeWidth, worldSizeWidth), worldSizeHeight * 2, 0), Quaternion.Euler(0, 0, 180));
            yield return new WaitForSeconds(enemySpawnRate);
        }
    }

    IEnumerator SpawnPowerUp()
    {
        while(canSpawn == true)
        {
            int randomPowerUp = Random.Range(0, powerUpPrefabs.Length);
            Instantiate(powerUpPrefabs[randomPowerUp], new Vector3(Random.Range(-worldSizeWidth, worldSizeWidth), worldSizeHeight * 2, 0), Quaternion.identity);
            yield return new WaitForSeconds(speedPowerUpSpawnRate);
        }
    }
}
