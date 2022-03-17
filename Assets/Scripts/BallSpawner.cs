using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    [SerializeField] TrapEvent trapEvent;
    [SerializeField] int ballCountToSpawn = 20;
    [SerializeField] Transform ballContainer;
    [SerializeField] float spawnSpeed = 0.1f;

     void Start()
    {
        trapEvent.OnTrapTrigger += SpawnBalls;
    }
     void SpawnBalls(TrapData data)
    {
        StartCoroutine(SpawnBallCycle());
    }
    
    private IEnumerator SpawnBallCycle()
    {
       
        for(int i =0; i<ballCountToSpawn; i++)
        {
        var go = Instantiate(ballPrefab, ballContainer);
        go.transform.position = RandomPosition();
        yield return new WaitForSecondsRealtime(spawnSpeed);
        }
          
    }

    Vector3 RandomPosition()
    {
        float minX = -transform.localScale.x;
        float maxX = transform.localScale.x;

        float minZ = -transform.localScale.z;
        float maxZ = transform.localScale.z;
                          
        Vector3 result = transform.position;
        result.x = Random.Range(minX, maxX);
        result.z = Random.Range(minZ, maxZ);
        return result;
    }
}
