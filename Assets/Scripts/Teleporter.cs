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

    public GameObject defaultTeleporter;

    private string mood;

    public UnityEvent entryHorny;
    public UnityEvent entryHungry;
    public UnityEvent entryDepressed;
    public UnityEvent entryDefault;
    public UnityEvent exitEvent;
    

    private bool active;
    private bool inactive;

    private void Update()
    {
        mood = ((Ink.Runtime.StringValue)DialogueManager.GetInstance().GetVariableState("globalmood")).value;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (inactive) return;

        if (collision.CompareTag("Player"))
        {
            entryDefault.Invoke();

            switch (mood)
            {
                case "Horny":
                    entryHorny.Invoke();
                    //collision.transform.position = hornyTeleporter.transform.position;
                    if(hornyTeleporter != null)
                    hornyTeleporter.GetComponent<Teleporter>().Inactive();
                    break;
                case "Hungry":
                    entryHungry.Invoke();
                    if (hornyTeleporter != null)
                    {
                        collision.transform.position = hungryTeleporter.transform.position;
                        hungryTeleporter.GetComponent<Teleporter>().Inactive();
                    }
                    break;
                case "Depressed":
                    entryDepressed.Invoke();
                    //collision.transform.position = hornyTeleporter.transform.position;
                    depressedTeleporter.GetComponent<Teleporter>().Inactive();
                    break;
                default:
                    if (defaultTeleporter == null) return;
                    collision.transform.position = defaultTeleporter.transform.position;
                    defaultTeleporter.GetComponent<Teleporter>().Inactive();
                    //Debug.Log("you twat");
                    break;
            }

            
            if (defaultTeleporter != null)
            {
                defaultTeleporter.GetComponent<Teleporter>().Inactive();
            }
            if (depressedTeleporter != null)
            {
                depressedTeleporter.GetComponent<Teleporter>().Inactive();
            }
            if (hornyTeleporter != null)
            {
                hornyTeleporter.GetComponent<Teleporter>().Inactive();
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