using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Teleporter : MonoBehaviour
{
    private string sceneToLoad;

    private void Update()
    {
        sceneToLoad = ((Ink.Runtime.StringValue)DialogueManager.GetInstance().GetVariableState("globalmood")).value;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(sceneToLoad != "")
            {
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }
}

