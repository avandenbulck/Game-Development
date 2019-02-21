using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstaclePatterns;

    public float timeBtwnSpawns;
    public float decreaseTime;
    public float minTime = 0.65f;

    void Start()
    {
        StartCoroutine(SpawnObstacle());
    }

    private IEnumerator SpawnObstacle()
    {
        while (true)
        { 
            if (timeBtwnSpawns > minTime)
            {
                timeBtwnSpawns -= decreaseTime;
            }

            int rand = Random.Range(0, obstaclePatterns.Length);
            Instantiate(obstaclePatterns[rand], transform.position, Quaternion.identity);

            yield return new WaitForSeconds(timeBtwnSpawns);
        }  
    }
}
