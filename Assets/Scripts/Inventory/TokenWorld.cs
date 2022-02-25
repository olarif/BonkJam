using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenWorld : MonoBehaviour
{
    private Item item;

    public static TokenWorld SpawnTokenWorld(Vector3 position, Item item)
    {
        Transform transform = Instantiate(ItemAssets.Instance.pfTokenWorld, position, Quaternion.identity);

        TokenWorld tokenWorld = transform.GetComponent<TokenWorld>();

        return tokenWorld;
    }

    public Item GetItem()
    {
        return item;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
