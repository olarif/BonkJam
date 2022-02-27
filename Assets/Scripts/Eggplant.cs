using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eggplant : MonoBehaviour
{
    public bool greenEggplant = false;
    public bool whiteEggplant = false;
    public bool PurpleEggplant = false;

    public EggplantManager manager;


    public void Bonked()
    {
        Debug.Log("Bonk");
        manager.bonks++;

        if (greenEggplant && manager.bonks == 1)
        {
            this.gameObject.SetActive(false);
        }

        if (whiteEggplant && manager.bonks == 2)
        {
            this.gameObject.SetActive(false);
        }

        if (PurpleEggplant && manager.bonks == 3)
        {
            this.gameObject.SetActive(false);
            manager.Done();
        }

        if ((greenEggplant && manager.bonks != 1) || (whiteEggplant && manager.bonks != 2) || (PurpleEggplant && manager.bonks != 3))
        {
            manager.bonks = 0;
            manager.Reset();
        }
    }
}
