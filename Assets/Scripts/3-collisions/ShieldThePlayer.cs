﻿using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class ShieldThePlayer : MonoBehaviour
{
    [Tooltip("The number of seconds that the shield remains active")]
    [SerializeField] float duration;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Shield triggered by player");
            var destroyComponent = other.GetComponent<DestroyOnTrigger2D>();
            if (destroyComponent)
            {
                ShieldTemporarily(destroyComponent);
                Destroy(this.gameObject); // Destroy the shield itself - to prevent double-use
            }
        }
        else
        {
            Debug.Log("Shield triggered by " + other.name);
        }
    }

    private async void ShieldTemporarily(DestroyOnTrigger2D destroyComponent)
    {
        destroyComponent.enabled = false;
        for (float t = duration; t > 0; t--)
        {
            Debug.Log("Shield: " + t + " seconds remaining!");
            await Awaitable.WaitForSecondsAsync(1);
        }
        Debug.Log("Shield gone!");
        destroyComponent.enabled = true;
    }

    /* OLD CODE --- using coroutines
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            Debug.Log("Shield triggered by player");
            var destroyComponent = other.GetComponent<DestroyOnTrigger2D>();
            if (destroyComponent) {
                destroyComponent.StartCoroutine(ShieldTemporarily(destroyComponent));        // co-routine
                    // NOTE: If you just call "StartCoroutine", then it will not work, 
                    //       since the present object is destroyed!
                Destroy(gameObject);  // Destroy the shield itself - prevent double-use
            }
        } else {
            Debug.Log("Shield triggered by "+other.name);
        }
    }

    private IEnumerator ShieldTemporarily(DestroyOnTrigger2D destroyComponent) {   // co-routines
        destroyComponent.enabled = false;
        for (float i = duration; i > 0; i--) {
            Debug.Log("Shield: " + i + " seconds remaining!");
            yield return new WaitForSeconds(1);       // co-routines
        }
        Debug.Log("Shield gone!");
        destroyComponent.enabled = true;
    }
    */
}