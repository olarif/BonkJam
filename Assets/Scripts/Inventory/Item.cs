using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
    public enum ItemType
    {
        DepressedToken,
        HornyToken,
        HungryToken
    }

    public ItemType itemType;
}


