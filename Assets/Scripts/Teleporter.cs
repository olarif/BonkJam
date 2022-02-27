using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject hornyTeleporter;
    public GameObject hungryTeleporter;
    public GameObject depressedTeleporter;
    public GameObject defaultTeleporter;

    private string mood;
    private bool inactive;

    public bool simpleTeleporter = false;

    private void Update()
    {
        mood = ((Ink.Runtime.StringValue)DialogueManager.GetInstance().GetVariableState("globalmood")).value;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (inactive) return;

        if (collision.CompareTag("Player"))
        {
            if (simpleTeleporter)
            {
                collision.transform.position = defaultTeleporter.transform.position;
                defaultTeleporter.GetComponent<Teleporter>().Inactive();
            } 
            
            else
            {
                switch (mood)
                {
                    case "Horny":
                        if (hornyTeleporter == null) return;
                        collision.transform.position = hornyTeleporter.transform.position;
                        hornyTeleporter.GetComponent<Teleporter>().Inactive();
                        break;
                    case "Hungry":
                        if (hungryTeleporter == null) return;
                        collision.transform.position = hungryTeleporter.transform.position;
                        hungryTeleporter.GetComponent<Teleporter>().Inactive();
                        break;
                    case "Depressed":
                        if (depressedTeleporter == null) return;
                        collision.transform.position = depressedTeleporter.transform.position;
                        depressedTeleporter.GetComponent<Teleporter>().Inactive();
                        break;
                }
            }

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
