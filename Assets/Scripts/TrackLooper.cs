using UnityEngine;

public class TrackLooper : MonoBehaviour
{
    public float tileLength = 30f; // Ʈ�� �� Ÿ���� ����
    public Transform player;

   
    void Update()
    {

        if (player.position.z - transform.position.z > tileLength)
        {
            transform.position += new Vector3(0, 0, tileLength * 3); // Ʈ�� 3���� ��� ��Ȱ��
        }


    }
}
