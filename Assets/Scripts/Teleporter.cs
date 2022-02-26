using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Teleporter : MonoBehaviour
{
    public GameObject partnerTeleporter;

    private bool active;
    private bool inactive;

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (inactive) return;
            collision.transform.position = partnerTeleporter.transform.position;
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            partnerTeleporter.GetComponent<Teleporter>().Inactive();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inactive = false;
    }

    public void Active()
    {
        inactive = false;
    }

    public void Inactive()
    {
        inactive = true;
    }
}