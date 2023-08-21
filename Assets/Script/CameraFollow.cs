using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;      // Pemain yang ingin diikuti
    public float smoothSpeed = 0.125f;  // Kecepatan smoothing

    public Vector3 offset;  // Jarak antara kamera dan pemain
    public Transform limitBegin, limitEnd;

    private GameObject userInterface;

    void Awake()
    {
        userInterface = GameObject.FindGameObjectWithTag("EditorOnly");
        userInterface.transform.GetChild(1).gameObject.SetActive(false);
    }

    private void LateUpdate()
    {
        try
        {
            if (transform.position.x > limitBegin.position.x && transform.position.y > limitBegin.position.y &&
                transform.position.x < limitEnd.position.x && transform.position.y < limitEnd.position.y )
            {
                Vector3 desiredPosition = target.position + offset;
                Vector3 smoothedPosition = Vector2.Lerp(transform.position, desiredPosition, smoothSpeed);

                transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
            }
        }
        catch (MissingReferenceException)
        {
            GameOver();   
        }
    }

    private void GameOver()
    {
        userInterface.transform.GetChild(1).gameObject.SetActive(true);
    }


}