using UnityEngine;

public class Reset : MonoBehaviour
{
    public float threshold = -25f;
    public Transform respawnPoint;

    private void Update()
    {
        // Fall threshold check
        if (transform.position.y < threshold)
        {
            TeleportToRespawn();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            TeleportToRespawn();
        }
    }

    private void TeleportToRespawn()
    {
        transform.position = respawnPoint.position;
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero; // Stop movement
        }
    }
}
