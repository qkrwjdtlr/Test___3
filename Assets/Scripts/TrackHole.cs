using UnityEngine;

public class TrackHole : MonoBehaviour
{
    [Header("TrackHole")]
    [SerializeField]
    private GameObject[] segment;

    void Start()
    {
        for (int i = 0; i < segment.Length; i++)
        {
            segment[i].transform.localPosition = new Vector3(0, 0, i * 5);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
