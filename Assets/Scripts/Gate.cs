using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void RotateLeft()
    {
        anim.Play("rotateLeft");
    }

    public void RotateRight()
    {
        anim.Play("rotateRight");
    }

    public void Reset()
    {
        anim.Play("RotatingGate");
    }
}
