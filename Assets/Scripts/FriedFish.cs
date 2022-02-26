using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriedFish : MonoBehaviour
{
    public Transform spawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //collision.transform.position = GameManager.instance.lastCheckPointPos;
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            collision.gameObject.transform.position = spawnPoint.position;
        }
    }
}
