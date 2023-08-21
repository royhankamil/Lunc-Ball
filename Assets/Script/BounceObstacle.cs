using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceObstacle : MonoBehaviour
{
    public float squashFactor = 1.4f, duration = 0.3f;
    public Vector3 initialScale;

    void Start()
    {
        initialScale = transform.localScale;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.transform.position.y > transform.position.y)
            {
                StartCoroutine(other.gameObject.GetComponent<BallMovement>().Jump(0f, 30f));
                StartCoroutine(GetJump());
            }
        }
    }

    IEnumerator GetJump()
    {
        Vector3 target = new Vector3(initialScale.x * squashFactor, initialScale.y, initialScale.z);

        transform.localScale = target;

        yield return new WaitForSeconds(duration);

        transform.localScale = initialScale;
    }
}
