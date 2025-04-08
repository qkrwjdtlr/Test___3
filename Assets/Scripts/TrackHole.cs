using UnityEngine;

public class TrackHole : MonoBehaviour
{
    public GameObject[] segment;

    void Start()
    {
        for (int i = 0; i < segment.Length; i++)
        {
            segment[i].transform.localPosition = new Vector3(0, 0, i * 5);
        }
    }


    void Update()
    {

    }
}
