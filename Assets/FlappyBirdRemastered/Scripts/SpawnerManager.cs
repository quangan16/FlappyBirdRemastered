using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public static GameObject obstaclePrefab;
    [SerializeField] private float spawnRate;
    private float nextSpawnTime;
    private float obstacleExistDuration = 3.0f;

    [SerializeField] private float offsetY;
    public void Update()
    {
        if (GameManager.Instance.isPlaying && GameManager.Instance.player.isAlive)
        {
            if (Time.time >= nextSpawnTime)
            {
                float randomPosY = Random.Range(transform.position.y - offsetY, transform.position.y + offsetY);
                randomPosY = Mathf.Clamp(randomPosY,-5.0f, 10.0f);
                Vector3 randomPosition = new Vector3(transform.position.x, randomPosY, transform.position.z);
                
                GameObject newObstacle = Instantiate(obstaclePrefab, randomPosition, Quaternion.identity);
                transform.position = randomPosition;
                nextSpawnTime = Time.time + spawnRate;
                Destroy(newObstacle, obstacleExistDuration);
            }
        }
    }

}
