using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoodTest : MonoBehaviour
{
    [SerializeField] private Color defaultColor = Color.white;
    [SerializeField] private Color hornyColor = Color.magenta;
    [SerializeField] private Color hungryColor = Color.green;
    [SerializeField] private Color depressedColor = Color.red;

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        string mood = ((Ink.Runtime.StringValue)DialogueManager.GetInstance().GetVariableState("globalmood")).value;

        switch (mood)
        {
            case "":
                sr.color = defaultColor;
                break;
            case "Hungry":
                sr.color = hungryColor;
                break;
            case "Horny":
                sr.color = hornyColor;
                break;
            case "Depressed":
                sr.color = depressedColor;
                break;
            default:
                break;
        }
    }
}
