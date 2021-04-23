using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public int count = 3;

    public float timeBetSpawnMin = 0.25f;
    public float timeBetSpawnMax = 1.25f;
    private float timeBetSpawn;

    public float yPosMin = -3.5f;
    public float yPosMax = 1.5f;
    public float xPos = 20f;

    private GameObject[] platforms;
    private int currenIndex = 0;

    private Vector2 poolPosition = new Vector2(0, -25);
    private float lastSpawnTime;

    void Start()
    {
        platforms = new GameObject[count];
        for(int i=0; i<count; i++)
        {
            platforms[i] = Instantiate(platformPrefab, poolPosition, Quaternion.identity);
        }
        lastSpawnTime = 0f;
        timeBetSpawn = 0f;
    }

    void Update()
    {
        if (GameManager.instance.isGameover)
        {
            return;
        }
        if(Time.time >= lastSpawnTime + timeBetSpawn)
        {
            lastSpawnTime = Time.time;
            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);

            float yPos = Random.Range(yPosMin, yPosMax);

            platforms[currenIndex].SetActive(false);
            platforms[currenIndex].SetActive(true);

            platforms[currenIndex].transform.position = new Vector2(xPos, yPos);
            currenIndex++;  //  0, 1, 2, ...

            if(currenIndex >= 3)
            {
                currenIndex = 0;
            }
        }
    }
}
