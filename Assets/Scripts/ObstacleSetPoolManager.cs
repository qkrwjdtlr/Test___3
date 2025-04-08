using UnityEngine;
using System.Collections.Generic;

public class ObstacleSetPoolManager : MonoBehaviour
{

    public GameObject obstacleGroupPrefab;
    public int poolSize = 10;
    public float spawnInterval = 20f;
    public float spawnAheadDistance = 60f;
    public float disableDistance = 30f; // �÷��̾�� �� �Ÿ� �ڿ� ���� ��Ȱ��ȭ
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
        // �÷��̾� ������ ���ο� ��ֹ� ��ġ
        if (player.position.z + spawnAheadDistance > nextSpawnZ)
        {
            SpawnObstacle(nextSpawnZ);
            nextSpawnZ += spawnInterval;
        }

        // �÷��̾� �ڷ� �� ��ֹ� ��Ȱ��ȭ �� ����
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

        // ��� �ڽ� ��Ȱ��ȭ
        foreach (Transform child in obj.transform)
        {
            child.gameObject.SetActive(true);
        }

        // ���� �ڽ� �ϳ��� Ȱ��ȭ
        int randomIndex = Random.Range(0, obj.transform.childCount);
        obj.transform.GetChild(randomIndex).gameObject.SetActive(false);
        activeObstacles.Add(obj);
    }
}
