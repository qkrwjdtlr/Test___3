using UnityEngine;
using System.Collections.Generic;

public class CoinPool : MonoBehaviour
{
    public GameObject coinPrefab;
    public int poolSize = 20;

    private Queue<GameObject> pool = new Queue<GameObject>();

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject coin = Instantiate(coinPrefab);
            coin.SetActive(false);
            coin.transform.SetParent(transform);
            pool.Enqueue(coin);
        }
    }

    public GameObject GetCoin()
    {
        if (pool.Count > 0)
        {
            GameObject coin = pool.Dequeue();
            coin.SetActive(true);
            return coin;
        }
        else
        {
            // 풀에 남은 코인이 없으면 새로 생성 (옵션)
            GameObject coin = Instantiate(coinPrefab);
            coin.SetActive(true);
            return coin;
        }
    }

    public void ReturnCoin(GameObject coin)
    {
        coin.SetActive(false);
        coin.transform.SetParent(transform);
        pool.Enqueue(coin);
    }
}
