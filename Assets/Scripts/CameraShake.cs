using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform camTransform;


    public float shakeSpeed;
    public float shakeTime;

    Vector3 OriginalPos;
    void Start()
    {
        OriginalPos = camTransform.position;

        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeTime > 0)
        {

            Debug.Log(shakeTime);
            camTransform.localPosition = OriginalPos + Random.insideUnitSphere * shakeSpeed;

            shakeTime -= Time.deltaTime;
        }
        else
        {
            shakeTime = 0f;
            camTransform.localPosition = OriginalPos;
        }
    }

}
