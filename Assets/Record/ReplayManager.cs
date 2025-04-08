using UnityEngine;
using System.Collections.Generic;

public class ReplayManager : MonoBehaviour
{
    public GameObject player;
    public bool isRecording = false;
    public bool isReplaying = false;
    public float recordInterval = 0.05f;

    public List<ReplayFrame> frames = new List<ReplayFrame>();
    private float timer = 0f;
    private int replayIndex = 0;

    private float replayStartTime = 0f;


    private void RecordFrame()
    {
        ReplayFrame frame = new ReplayFrame();
        frame.time = Time.time;
        frame.position = player.transform.position;
        frame.rotation = player.transform.rotation;
        frames.Add(frame);
        Debug.Log(frame);
        //Debug.Log($"Frame Recorded: {frame.time}, {frame.position}");
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R)) StartRecording();
        if (Input.GetKeyDown(KeyCode.P)) StartReplay();

        if (isRecording)
        {
            timer += Time.deltaTime;
            if (timer >= recordInterval)
            {
                timer = 0f;
                RecordFrame(); // 오직 여기서만 기록
            }
        }

        if (isReplaying && replayIndex < frames.Count)
        {
            float elapsedTime = Time.time - replayStartTime;

            if (elapsedTime >= frames[replayIndex].time - frames[0].time)
            {
                player.transform.position = frames[replayIndex].position;
                player.transform.rotation = frames[replayIndex].rotation;
                replayIndex++;
            }

            if (replayIndex >= frames.Count)
            {
                isReplaying = false;
                Debug.Log("Replay Ended");
            }
        }
    }


    private void Update()
    {

        
    }

    public void StartRecording()
    {
        frames.Clear();
        isRecording = true;
        isReplaying = false;
        timer = 0f;
    }

    public void StartReplay()
    {
        isRecording = false;
        isReplaying = true;
        replayIndex = 0;
        replayStartTime = Time.time;
    }

}
