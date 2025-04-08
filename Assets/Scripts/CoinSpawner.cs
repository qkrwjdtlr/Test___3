using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public CoinPool coinPool;
    public Transform player; // 플레이어 위치 추적용
    public float spawnAheadDistance = 60f; // 플레이어보다 얼마나 앞에 코인을 생성할지
    public float spawnIntervalZ = 10f; // Z축 간격
    public float trackLength = 30f; // 트랙 길이
    public float[] trackX = { -2f, 0f, 2f }; // 3개 트랙 X 좌표
    public float coinY = 1f; // 코인 높이

    [SerializeField]
    private float nextSpawnZ = 0f;

    void Start()
    {
        nextSpawnZ = player.position.z + spawnAheadDistance;
    }

    void Update()
    {
        while (nextSpawnZ < player.position.z + spawnAheadDistance)
        {
            
            SpawnCoinsAtZ(nextSpawnZ);
            nextSpawnZ += spawnIntervalZ;
        }
    }

    void SpawnCoinsAtZ(float z)
    {
        // 하나의 트랙만 선택해서 코인 배치
        int lane = Random.Range(0, 3);
        Vector3 spawnPos = new Vector3(0, lane, z);

        GameObject coin = coinPool.GetCoin();
        coin.transform.position = spawnPos;
        coin.GetComponent<Coin>().Init(coinPool);
    }
}
