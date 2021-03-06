using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    public TextAsset tokenScript;

    private bool playerInRange;

    public void StartDialogue()
    {
        if (GameManager.instance.allCollected)
        {
            DialogueManager.GetInstance().EnterDialogueMode(tokenScript);
        } else
        {
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
        }
    }

    private void Update()
    {
        if (playerInRange)
        {
            visualCue.SetActive(true);

            /*

            if (!DialogueManager.GetInstance().isPlaying && Input.GetKeyDown(KeyCode.E))
            {

                if (GameManager.instance.allCollected)
                {
                    DialogueManager.GetInstance().EnterDialogueMode(tokenScript);
                } else
                {
                    DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                }
                
            }

            */
        }
        else
        {
            visualCue.SetActive(false);
        }
    }

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
