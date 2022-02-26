using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


public class Teleporter : MonoBehaviour
{
    public GameObject hornyTeleporter;
    public GameObject hungryTeleporter;
    public GameObject depressedTeleporter;

    private string mood;

    public UnityEvent entryHorny;
    public UnityEvent entryHungry;
    public UnityEvent entryDepressed;

    public UnityEvent exitEvent;
    

    private bool active;
    private bool inactive;

    private void Start()
    {
        
    }

    private void Update()
    {
        mood = ((Ink.Runtime.StringValue)DialogueManager.GetInstance().GetVariableState("globalmood")).value;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (inactive) return;

        if (collision.CompareTag("Player"))
        {
            switch (mood)
            {
                case "Horny":
                    entryHorny.Invoke();
                    //collision.transform.position = hornyTeleporter.transform.position;
                    //hornyTeleporter.GetComponent<Teleporter>().Inactive();
                    break;
                case "Hungry":
                    
                    collision.transform.position = hungryTeleporter.transform.position;
                    hungryTeleporter.GetComponent<Teleporter>().Inactive();
                    entryHungry.Invoke();
                    break;
                case "Depressed":
                    entryDepressed.Invoke();
                    //collision.transform.position = hornyTeleporter.transform.position;
                    //depressedTeleporter.GetComponent<Teleporter>().Inactive();
                    break;
                default:
                    Debug.Log("you twat");
                    break;
            }

            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inactive = false;
        exitEvent.Invoke();
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