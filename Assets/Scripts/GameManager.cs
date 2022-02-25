using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Vector2 lastCheckPointPos;
    //public TMP_Text health;

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

    void Update()
    {
        
    }
}
