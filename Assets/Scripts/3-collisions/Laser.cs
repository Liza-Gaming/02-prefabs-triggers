using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [Range(1, 10)]
    [Tooltip("The speed at which the laser moves.")]
    [SerializeField] private float speed = 10f;

    [Range(1, 10)]
    [Tooltip("The lifetime of the laser before it gets destroyed (in seconds).")]
    [SerializeField] private float lifetime = 3f;

    [Tooltip("The tag of the GameObject that the laser will trigger on collision.")]
    [SerializeField] string triggeringTag;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.rotation = Quaternion.Euler(0, 0, 0);
        Destroy(gameObject, lifetime); // Destroy the laser after a set lifetime
    }

    // Sets the linear velocity of the laser to move in the up direction.
    private void FixedUpdate()
    {
        rb.linearVelocity = transform.up * speed;
    }

    // Destroys the laser and the object it collides with if the triggering tag matches.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == triggeringTag && enabled)
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            ScoreManager.instance.AddPoint(); //// Add a point to the score
        }
    }

}