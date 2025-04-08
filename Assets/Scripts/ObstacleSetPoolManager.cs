using UnityEngine;
using System.Collections.Generic;

public class ObstacleSetPoolManager : MonoBehaviour
{

    public GameObject obstacleGroupPrefab;
    public int poolSize = 10;
    public float spawnInterval = 20f;
    public float spawnAheadDistance = 60f;
    public float disableDistance = 30f; // 플레이어보다 이 거리 뒤에 가면 비활성화
    public Transform player;
    
    private Queue<GameObject> pool = new Queue<GameObject>();
    private List<GameObject> activeObstacles = new List<GameObject>();
    private float nextSpawnZ = 30f;

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(obstacleGroupPrefab, Vector3.one * 999f, Quaternion.identity);
            obj.SetActive(false);
            obj.transform.SetParent(transform);
            pool.Enqueue(obj);
        }
    }

    void Update()
    {
        // 플레이어 앞으로 새로운 장애물 배치
        if (player.position.z + spawnAheadDistance > nextSpawnZ)
        {
            SpawnObstacle(nextSpawnZ);
            nextSpawnZ += spawnInterval;
        }

        // 플레이어 뒤로 간 장애물 비활성화 및 재사용
        for (int i = activeObstacles.Count - 1; i >= 0; i--)
        {
            GameObject obj = activeObstacles[i];
            if (player.position.z - obj.transform.position.z > disableDistance
                )
            {
                obj.SetActive(false);
                activeObstacles.RemoveAt(i);
                pool.Enqueue(obj);
            }
        }
    }

    void SpawnObstacle(float zPos)
    {
        if (pool.Count == 0) return;

        GameObject obj = pool.Dequeue();
        obj.transform.position = new Vector3(0f, 1f, zPos);
        obj.SetActive(true);

        // 모든 자식 비활성화
        foreach (Transform child in obj.transform)
        {
            child.gameObject.SetActive(true);
        }

        // 랜덤 자식 하나만 활성화
        int randomIndex = Random.Range(0, obj.transform.childCount);
        obj.transform.GetChild(randomIndex).gameObject.SetActive(false);
        activeObstacles.Add(obj);
    }
}
