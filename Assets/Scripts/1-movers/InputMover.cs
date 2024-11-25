using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class InputMover : MonoBehaviour
{
    [Tooltip("Speed of movement, in meters per second")]
    [SerializeField] float speed = 10f;

    [Tooltip("Input action for movement.")]
    [SerializeField]
    InputAction move = new InputAction(
        type: InputActionType.Value, expectedControlType: nameof(Vector2));

    [Tooltip("Input action for shooting.")]
    [SerializeField]
    InputAction shootAction = new InputAction(
        type: InputActionType.Button, expectedControlType: "Button");

    [Tooltip("Point from where the laser will be fired.")]
    [SerializeField] private Transform firingPoint;

    [Tooltip("Laser prefab to instantiate upon shooting.")]
    [SerializeField] private GameObject laserPrefab;

    [Tooltip("Knockback force applied upon collision.")]
    [SerializeField] private float knockbackForce = 1f;

    [Tooltip("Duration for which the player continues to move in the knockback direction.")]
    [SerializeField] private float knockbackDuration = 1f;
    private bool isKnockedBack = false;

    private Rigidbody2D rb;

    void OnEnable()
    {
        move.Enable();
        shootAction.Enable();
    }

    void OnDisable()
    {
        move.Disable();
        shootAction.Disable();
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isKnockedBack) // Only allow movement if not knocked back
        {
            Vector2 moveDirection = move.ReadValue<Vector2>();
            Vector3 movementVector = new Vector3(moveDirection.x, moveDirection.y, 0) * speed * Time.deltaTime;
            transform.position += movementVector;

            // Check if the shoot action is performed
            if (shootAction.WasPerformedThisFrame())
            {
                Shoot();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Meteor"))
        {
            Destroy(other.gameObject); // Destroy the meteor upon collision
            Vector2 knockbackDirection = (transform.position - other.transform.position).normalized;
            rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse); // Apply knockback force

            StartCoroutine(ContinueMovementAfterCollision(knockbackDirection));
        }
    }

    private IEnumerator ContinueMovementAfterCollision(Vector2 direction)
    {
        isKnockedBack = true; // Set knockback state

        // Keep applying movement in the knockback direction for a duration
        float elapsedTime = 0f;
        while (elapsedTime < knockbackDuration)
        {
            rb.linearVelocity = direction * knockbackForce; // Move in knockback direction
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for next frame
        }

        // Stop the movement after the knockback duration
        rb.linearVelocity = Vector2.zero;
        isKnockedBack = false; // Reset knockback state
    }

    // Shoot the laser
    private void Shoot()
    {
        Instantiate(laserPrefab, firingPoint.position, firingPoint.rotation);
    }

}