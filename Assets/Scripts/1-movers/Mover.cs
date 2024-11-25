﻿using UnityEngine;

/**
 * This component moves its object in a fixed velocity.
 * NOTE: velocity is defined as speed+direction.
 *       speed is a number; velocity is a vector.
 */
public class Mover: MonoBehaviour {
    [Tooltip("Movement vector in meters per second")]
    [SerializeField] Vector3 velocity;
    [SerializeField] private float lifetime = 8f;
    void Start()
    {
        if(this.tag == "Enemy")
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }

        Destroy(gameObject, lifetime);
    }
    void Update() {
        transform.position += velocity * Time.deltaTime;
    }

    public void SetVelocity(Vector3 newVelocity) {
        this.velocity = newVelocity;
    }
}
