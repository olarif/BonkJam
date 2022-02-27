using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Vector2 lastCheckPointPos;
    //public TMP_Text health;

    private CinemachineVirtualCamera centerCam;
    private CinemachineVirtualCamera toxicCam;
    private CinemachineVirtualCamera hungryCam;
    private CinemachineVirtualCamera hornyCam;
    private CinemachineVirtualCamera depressedCam;

    private Inventory inventory;

    public bool allCollected = false;

    public bool hornyToken = false;
    public bool hungryToken = false;
    public bool depressedToken = false;

    [HideInInspector] public bool chatActive = false;

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        instance = this;
    }

    private void Start()
    {
        inventory = new Inventory();

        if(hornyToken && hungryToken && depressedToken)
        {
            allCollected = true;
        }

        //health.text = "x " + Random.Range(-10, 10);
    }
    
    public void ResetMood()
    {
        ((Ink.Runtime.StringValue)DialogueManager.GetInstance().GetVariableState("globalmood")).value = "";
    }

    void Update()
    {
        
    }
}
