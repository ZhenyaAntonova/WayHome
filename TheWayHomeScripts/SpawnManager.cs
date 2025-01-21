using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] obstaclePrefabs;
    [SerializeField] WayHomeSceneManager manager;

    WaitForSeconds wait;
    float spawnTime = 5.0f;
    public int spawnCount = 0;
    int lastTarget = 0;
    int lastIndex = -1;

    float startPosX = 0f;
    float startPosY = 20.0f;
    float startPosZ = -12.5f;
    Vector3 startPos;

    void Start()
    {
        wait = new WaitForSeconds(spawnTime);
        startPos = new Vector3(startPosX, startPosY, startPosZ);
    }

    private void Update()
    {
        if(manager.sceneEnded)
        {
            StopSpawn();
        }
    }

    public void StopSpawn()
    {
        StopAllCoroutines();
    }

    public void Spawn()
    {
        StartCoroutine(SpawnObstacle());
    }

    IEnumerator SpawnObstacle()
    {
        while(manager.gameIsOn)
        {
            yield return wait;
            int randomIndex = Random.Range(0, obstaclePrefabs.Length);
            int randomTarget = Random.Range(1, 4);

            if(randomTarget == lastTarget)
            {
                randomTarget = Random.Range(1, 4);
            }
            
            if(randomIndex == lastIndex)
            {
                randomIndex = Random.Range(0, obstaclePrefabs.Length);
            }

            obstaclePrefabs[randomIndex].GetComponent<MoveObstacle>().targetNum = randomTarget;
            Instantiate(obstaclePrefabs[randomIndex], startPos, transform.rotation);
            spawnCount++;
            lastTarget = randomTarget;
            lastIndex = randomIndex;

            if(spawnCount >= manager.obstaclesToAvoid)
            {
                manager.InitHomePlanet();
            }
        }
    }
}
