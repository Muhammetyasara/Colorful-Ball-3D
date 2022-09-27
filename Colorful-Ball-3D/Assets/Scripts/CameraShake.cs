using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private bool shakeControl;

    public IEnumerator CameraShakes(float duration, float magnitude)
    {

        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            //float z = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, originalPos.y, originalPos.z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPos;
    }

    public void CameraShakesCall()
    {
        if (shakeControl == false)
        {
            StartCoroutine(CameraShakes(0.35f, 1f));
            shakeControl = true;
        }
    }
}
