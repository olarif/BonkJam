using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    GameManager gm;
    AudioManager am;
    PlayerController player;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        am = FindObjectOfType<AudioManager>();
        player = GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Toxic":
                gm.SwitchCam(collision.tag);
                am.Stop();
                am.Play("Bubbles");
                am.Play(collision.tag);
                player.SetState(PlayerController.moveState.normal);
                break;
            case "Center":
                gm.SwitchCam(collision.tag);
                am.Stop();
                am.Play(collision.tag);
                player.SetState(PlayerController.moveState.normal);
                break;
            case "Horny":
                gm.SwitchCam(collision.tag);
                am.Stop();
                am.Play(collision.tag);
                player.SetState(PlayerController.moveState.horny);
                break;
            case "Hungry":
                gm.SwitchCam(collision.tag);
                am.Stop();
                am.Play(collision.tag);
                player.SetState(PlayerController.moveState.normal);
                break;
            case "Depressed":
                gm.SwitchCam(collision.tag);
                am.Stop();
                am.Play(collision.tag);
                player.SetState(PlayerController.moveState.depressed);
                break;
        }
    }

}
