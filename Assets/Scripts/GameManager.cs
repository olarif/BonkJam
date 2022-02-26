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
