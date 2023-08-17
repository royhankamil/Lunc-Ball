using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Referensi ke transform pemain
    public float smoothSpeed = 0.125f; // Kecepatan smoothing

    public Vector3 offset; // Jarak antara kamera dan pemain

    void LateUpdate()
    {
        // Hitung posisi target yang diinginkan dengan offset
        Vector3 desiredPosition = target.position + offset;

        // Interpolasi smooth antara posisi kamera saat ini dan posisi target yang diinginkan
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        
        // Tetapkan posisi kamera yang telah di-smooth
        transform.position = smoothedPosition;
    }
}