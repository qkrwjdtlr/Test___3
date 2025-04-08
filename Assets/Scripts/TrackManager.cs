using UnityEngine;

public class TrackManager : MonoBehaviour
{
    [SerializeField]
    private int Count = 0;

    public Transform player;
    public float trackLength = 30f;
    public Transform[] tracks;


  

    void Update()
    {
        foreach (var track in tracks)
        {
            if (player.position.z - track.position.z > trackLength)
            {
                Count++;
                Vector3 newPos = track.position + new Vector3(0, 0, trackLength * tracks.Length);
                track.position = newPos;
               
            }
        }
    }
}
