using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


public class StairsTeleport : MonoBehaviour
{
    public GameObject partnerTeleporter;

    private bool inactive;

    private void Start()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (inactive) return;

        if (collision.CompareTag("Player"))
        {
            collision.transform.position = partnerTeleporter.transform.position;
            partnerTeleporter.GetComponent<StairsTeleport>().Inactive();
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

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
