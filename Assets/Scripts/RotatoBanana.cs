using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatoBanana : MonoBehaviour
{
    public float degreeValue;
    public bool clockwise;

    // Update is called once per frame
    void Update()
    {
        if (clockwise)
        {
            transform.Rotate(0f, 0f, -degreeValue, Space.Self);
        }
        else
        {
            transform.Rotate(0f, 0f, degreeValue, Space.Self);
        }
    }
}
