using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenWorldSpawner : MonoBehaviour
{
    public Item item;

    private void Awake()
    {
        TokenWorld.SpawnTokenWorld(transform.position, item);
        Destroy(gameObject);
    }
}
