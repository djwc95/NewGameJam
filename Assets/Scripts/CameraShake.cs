using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float duration = 1f;
    public AnimationCurve curve;

    public IEnumerator Shaking()
    {
        Vector3 startPosition = transform.position;
        float elpasedTime = 0f;

        while (elpasedTime< duration)
        {
            elpasedTime += Time.deltaTime;
            float strength = curve.Evaluate(elpasedTime / duration);
            transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }

        transform.position = startPosition;
    }
}
