using UnityEngine;

public class TrackManager : MonoBehaviour
{
    [SerializeField]
    private int Count = 0;
    public Transform player;
    public float trackLength = 30f;
    public Transform[] tracks;

    [SerializeField]
    private TrackHole[] m_trackHoles;

    int num;

    void Update()
    {
        foreach (var track in tracks)
        {
            if (player.position.z - track.position.z > trackLength)
            {
                Vector3 newPos = track.position + new Vector3(0, 0, trackLength * tracks.Length);
                track.position = newPos;
              
                m_trackHoles[Count].segment[num].SetActive(true);

                Count++;
                //1 -> 2 -> 0 
                if (Count == 3)
                    Count = 0;
                num = Random.Range(1, 6);
                //m_trackHoles[Count].segment[num].SetActive(false);
            }
        }
    }
}
