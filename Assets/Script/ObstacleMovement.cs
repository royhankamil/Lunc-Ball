using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement  : MonoBehaviour
{
    public float moveRangeX = 2f; // Jarak pergerakan horizontal
    public float moveRangeY = 2f; // Jarak pergerakan vertikal
    public float moveSpeed = 2f;  // Kecepatan pergerakan

    private Vector3 initialPosition;
    private float startTimeX;
    private float startTimeY;

    private Collider2D playerCollider;
    private bool playerOnTop = false;

    void Start()
    {
        initialPosition = transform.position;
        startTimeX = Time.time;
        startTimeY = Time.time;

        // Dapatkan Collider2D dari pemain
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
    }

    void Update()
    {
        float newX = initialPosition.x + Mathf.Sin((Time.time - startTimeX) * moveSpeed) * moveRangeX;
        float newY = initialPosition.y + Mathf.Sin((Time.time - startTimeY) * moveSpeed) * moveRangeY;

        transform.position = new Vector3(newX, newY, transform.position.z);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Cek apakah pemain bersentuhan dengan obyek
        if (collision.collider == playerCollider)
        {
            // Jadikan pemain anak dari obyek untuk mengikuti pergerakan
            collision.collider.transform.SetParent(transform);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Cek apakah pemain tidak lagi bersentuhan dengan obyek
        if (collision.collider == playerCollider)
        {
            // Hapus pemain dari anak obyek sehingga pemain tidak mengikuti pergerakan
            collision.collider.transform.SetParent(null);
        }
    }
}
