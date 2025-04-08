using System.Collections;
using UnityEngine;


public class CamShake : MonoBehaviour
{
    public float duration = 0.2f;      // ��鸮�� �ð�
    public float magnitude = 0.3f;     // ��鸲 ����

    private void FixedUpdate()
    {
      
    }

    public void Shake()
    {
        StartCoroutine(ShakeCoroutine());
    }


    private IEnumerator ShakeCoroutine()
    {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(originalPos.x + x, originalPos.y + y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }
    void Update()
    {

    }
}
