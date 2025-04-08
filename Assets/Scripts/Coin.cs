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
        // ���� �Ÿ� ������ �ڵ� ��ȯ (��: Z�� ����)
        if (Camera.main.transform.position.z - transform.position.z > 10f)
        {
            pool.ReturnCoin(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // ���⼭ ���� �ø��� ���� �־ ��
            pool.ReturnCoin(gameObject);
        }
    }




}
