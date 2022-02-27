using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class toxictrigger : MonoBehaviour
{
    public UnityEvent enterEvent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (GameManager.instance.allCollected)
        {
            enterEvent.Invoke();
        }
        
    }

}
