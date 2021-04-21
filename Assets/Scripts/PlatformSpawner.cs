using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public int count = 3;

    public float timeBeSpawn_Min = 1.25f;
    public float timeBeSpawn_Max = 2.25f;
    private float timeBetSpawn;

    public float minY = -3.5f;
    public float maxY = 1.5f;
    private float xPos = 20f;

    private GameObject[] platforms;
    private int currentIndex = 0;

    private Vector2 poolPos = new Vector2(0,-25);
    private float lastSpawnTime;

    private void Start()
    {
        platforms = new GameObject[count];

        for(int i = 0; i < count; i++)
        {
            platforms[i] = Instantiate(platformPrefab, poolPos, Quaternion.identity);
        }

        lastSpawnTime = 0f; timeBetSpawn = 0f;
    }

    private void Update()
    {
        if (GameManager.instance.isGameOver)
            return;

        if(Time.time >= lastSpawnTime + timeBetSpawn)
        {
            lastSpawnTime = Time.time;

            timeBetSpawn = Random.Range(timeBeSpawn_Min, timeBeSpawn_Max);

            float YPos = Random.Range(minY, maxY);

            platforms[currentIndex].SetActive(false);
            platforms[currentIndex].SetActive(true);

            platforms[currentIndex].transform.position = new Vector2(xPos, YPos);
            currentIndex++;

            if (currentIndex >= count)
                currentIndex = 0;
        }
    }
}
