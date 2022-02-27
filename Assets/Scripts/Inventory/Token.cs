using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{
    public bool hornyToken;
    public bool hungryToken;
    public bool depressedToken;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (depressedToken)
            {
                GameManager.instance.depressedToken = true;
            } else if (hornyToken)
            {
                GameManager.instance.hornyToken = true;
            } else if (hungryToken)
            {
                GameManager.instance.hungryToken = true;
            }
        }
    }
}
