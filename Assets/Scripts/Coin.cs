using UnityEngine;

public class Coin : MonoBehaviour
{

    private CoinPool pool;

    public void Init(CoinPool coinPool)
    {
        pool = coinPool;
    }

    void Update()
    {
        // 일정 거리 지나면 자동 반환 (예: Z축 기준)
        if (Camera.main.transform.position.z - transform.position.z > 10f)
        {
            pool.ReturnCoin(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 여기서 점수 올리는 로직 넣어도 됨
            pool.ReturnCoin(gameObject);
        }
    }




}
