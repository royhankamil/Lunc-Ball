using System;
using System.Collections;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float squashFactor = 0.8f; // Faktor "gepeng"
    public float returnDelay = 0.5f; // Waktu kembali ke ukuran normal setelah "gepeng" saat di tanah

    private Rigidbody2D rb;
    private Collider2D col;
    private bool isGrounded;

    private Vector3 initialScale; // Skala awal karakter

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        try{
            initialScale = transform.localScale;
        }
        catch(NullReferenceException)
        {
            Debug.LogError("Harus ada parent dan parent tidak ditemukan");
        }
    }

    void Update()
    {
        // Mengecek apakah bola bersentuhan dengan tanah
        isGrounded = Physics2D.IsTouchingLayers(col, LayerMask.GetMask("Ground"));

        // Menggerakkan bola horizontal
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 moveDirection = new Vector2(horizontalInput, 0f);
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);

        // Melompat jika bola bersentuhan dengan tanah dan tombol lompat ditekan
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            // rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            StartCoroutine(Jump(0.2f, jumpForce));
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Enemy"))    
        {
            Destroy(this.gameObject);
        }
    }

    public IEnumerator Jump(float duration, float force)
    {
        Vector3 target = new Vector3(initialScale.x, initialScale.y * squashFactor, initialScale.z);

        transform.localScale = target;

        yield return new WaitForSeconds(duration);

        transform.localScale = initialScale;

        
        rb.velocity = new Vector2(rb.velocity.x, force);
    }
}
