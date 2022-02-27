using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggplantManager : MonoBehaviour
{
    public GameObject greenEggplant;
    public GameObject whiteEggplant;
    public GameObject purpleEggplant;

    public GameObject token;

    public int bonks = 0;

    public void Reset()
    {
        bonks = 0;
        greenEggplant.SetActive(true);
        whiteEggplant.SetActive(true);
        purpleEggplant.SetActive(true);
    }

    public void Done()
    {
        token.SetActive(true);
    }

}
