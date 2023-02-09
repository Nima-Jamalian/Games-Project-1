using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float enemySpawnRate;
    [SerializeField] bool canSpawn = true;

    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(SpawnEnemey());


        //Debug.Log(Screen.height);
        //Debug.Log()
    }

    // Update is called once per frame
    void Update()
    {


    }

    IEnumerator SpawnEnemey()
    {
        while (canSpawn == true)
        {
            Instantiate(enemyPrefab, new Vector3(Random.Range(-2.7f,2.7f), 6.15f, 0), Quaternion.identity);
            yield return new WaitForSeconds(enemySpawnRate);
        }
    }
}
