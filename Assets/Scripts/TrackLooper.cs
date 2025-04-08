using UnityEngine;

public class TrackLooper : MonoBehaviour
{
    public float tileLength = 30f; // 트랙 한 타일의 길이
    public Transform player;

   
    void Update()
    {

        if (player.position.z - transform.position.z > tileLength)
        {
            transform.position += new Vector3(0, 0, tileLength * 3); // 트랙 3개를 계속 재활용
        }


    }
}
