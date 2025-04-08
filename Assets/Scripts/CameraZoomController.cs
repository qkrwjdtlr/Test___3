using System.Collections;
using UnityEngine;

public class CameraZoomController : MonoBehaviour
{
    public Transform player;                   // 플레이어 위치 추적
    public Camera cam;                         // 카메라
    public float minFOV = 60f;                 // 최소 FOV
    public float maxFOV = 80f;                 // 최대 FOV
    public float speedToMaxFOV = 20f;          // 이 속도일 때 max FOV
    public float smoothSpeed = 2f;             // FOV 전환 부드럽게

    private Rigidbody playerRb;

    void Start()
    {
        if (cam == null) cam = Camera.main;
        playerRb = player.GetComponent<Rigidbody>();
        StartCoroutine(SpeedZoomEffect());
    }







    IEnumerator SpeedZoomEffect()
    {
        float originalFOV = cam.fieldOfView;
        float boostedFOV = Mathf.Min(originalFOV + 10f, maxFOV);
        float t = 0f;

        while (t < 1.5f)
        {
            t += Time.deltaTime;
            cam.fieldOfView = Mathf.Lerp(boostedFOV, originalFOV, t);
            yield return null;
        }


        yield return new WaitForSeconds(4f); // 2초간 유지
        t = 0f;
        boostedFOV = cam.fieldOfView + 10f;
        while (t < 1.5f)
        {
            t += Time.deltaTime;
            cam.fieldOfView = Mathf.Lerp(originalFOV, boostedFOV, t);
            yield return null;
        }
    }


}
