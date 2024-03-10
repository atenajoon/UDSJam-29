using UnityEngine;

public class GroundedPlayer : MonoBehaviour
{
    public LayerMask groundLayer;
    public float raycastDistance = 0.1f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Cast a raycast downward from the player's position
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, groundLayer);

        // Check if the raycast hits the ground
        if (hit.collider != null)
        {
            // Adjust the player's position to stay grounded
            float groundY = hit.point.y + raycastDistance; // Adjust distance from the ground
            Vector2 newPosition = new Vector2(transform.position.x, groundY);
            transform.position = newPosition;

            // Alternatively, you can adjust the player's velocity to prevent climbing
            // rb.velocity = new Vector2(rb.velocity.x, 0f);
        }
    }
}
