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

    public GameObject centerCam;
    public GameObject toxicCam;
    public GameObject hornyCam;
    public GameObject hungryCam;
    public GameObject depressedCam;

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
        if (hornyToken && hungryToken && depressedToken)
        {
            allCollected = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void SwitchCam(string cam)
    {
        switch (cam)
        {
            case "Center":
                DisableCams();
                centerCam.SetActive(true);
                break;
            case "Toxic":
                DisableCams();
                toxicCam.SetActive(true);
                break;
            case "Horny":
                DisableCams();
                hornyCam.SetActive(true);
                break;
            case "Hungry":
                DisableCams();
                hungryCam.SetActive(true);
                break;
            case "Depressed":
                DisableCams();
                depressedCam.SetActive(true);
                break;
        }
    }

    private void DisableCams()
    {
        centerCam.SetActive(false);
        toxicCam.SetActive(false);
        hornyCam.SetActive(false);
        depressedCam.SetActive(false);
        hungryCam.SetActive(false);
    }
}
