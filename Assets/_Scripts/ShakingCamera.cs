using System.Collections;
using UnityEngine;

public class ShakingCamera : MonoBehaviour
{
    public float shakeDuration = 0.8f;
    private Transform cameraTransform;
    private Vector3 initialPosition;

    void Start()
    {
        cameraTransform = GetComponent<Transform>();
        initialPosition = cameraTransform.position;
    }

    public void StartShake()
    {
        StartCoroutine(ShakeCoroutine());
    }

    private IEnumerator ShakeCoroutine()
    {
        float xOffset;
        float yOffset;
        float startTime = Time.time;

        while ((startTime + shakeDuration) > Time.time)
        {
            xOffset = Random.Range(-0.1f, 0.1f);
            yOffset = Random.Range(-0.1f, 0.1f);

            cameraTransform.position = new Vector3(xOffset, yOffset, initialPosition.z);
            yield return new WaitForSeconds(0.025f);
        }

        cameraTransform.position = initialPosition;
    }
}