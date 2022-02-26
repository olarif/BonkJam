using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        
    }
}
