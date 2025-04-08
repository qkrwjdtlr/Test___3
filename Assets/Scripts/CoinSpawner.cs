using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public CoinPool coinPool;
    public Transform player; // �÷��̾� ��ġ ������
    public float spawnAheadDistance = 60f; // �÷��̾�� �󸶳� �տ� ������ ��������
    public float spawnIntervalZ = 10f; // Z�� ����
    public float trackLength = 30f; // Ʈ�� ����
    public float[] trackX = { -2f, 0f, 2f }; // 3�� Ʈ�� X ��ǥ
    public float coinY = 1f; // ���� ����

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
        // �ϳ��� Ʈ���� �����ؼ� ���� ��ġ
        int lane = Random.Range(0, 3);
        Vector3 spawnPos = new Vector3(0, lane, z);

        GameObject coin = coinPool.GetCoin();
        coin.transform.position = spawnPos;
        coin.GetComponent<Coin>().Init(coinPool);
    }
}
