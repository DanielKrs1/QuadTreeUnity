using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;


public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] units;
    public int[] prices;
    public GameObject[] buttons;

    public float SpawnXRange = 5.0f;
    public float SpawnYRange = 5.0f;
    public float FirstSpawnTime = 2.0f;
    public float SpawnIntervalConst = 1.0f;
    public Vector3 secondToLastClick;
    public Vector3 lastClick;
    public GameObject mainCamera;
    public int currentUnitType = 0;

    public GameObject panel;


    void Start()
    {
        panel = GameObject.Find("BuyPanel");
        ServiceLocator.Broker.SubEnd(OnEnd);
        ServiceLocator.Broker.SubStart(OnStart);
        setUnitType(0);
    }

    public void OnEnd()
    {
        this.enabled = true;
        panel.SetActive(!panel.activeSelf);
    }

    public void OnStart()
    {
        this.enabled = false;
        panel.SetActive(!panel.activeSelf);
    }

    void Update()
    {
        // Buy unit with shift-click
        if (Input.GetMouseButtonUp(0) && Input.GetKey(KeyCode.LeftShift))
        {
            lastClick = mainCamera.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
            lastClick.z = 0;
            BuyUnit(currentUnitType, lastClick);

        }
        // Undo with z
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ServiceLocator.Invoker.Undo();
        }

        // Redo with r
        if (Input.GetKeyDown(KeyCode.R))
        {
            ServiceLocator.Invoker.Redo();
        }
    }

    public void setUnitType(int unitID)
    {
        currentUnitType = unitID;

        for (int i = 0; i < buttons.Length; i++)
        {
            if (i == unitID)
            {
                buttons[i].GetComponent<UnityEngine.UI.Image>().color = Color.green;
            }
            else
            {
                buttons[i].GetComponent<UnityEngine.UI.Image>().color = Color.white;
            }
        }
    }
    public void BuyUnit(int unitID, Vector3 inputPosititon)
    {
        Vector3 position = new Vector3(UnityEngine.Random.Range(-SpawnXRange, SpawnXRange), UnityEngine.Random.Range(-SpawnYRange, SpawnYRange), 0);
        position = inputPosititon;
        if (ServiceLocator.GameState.Phase == 1)
        {
            CommandBuyUnit command = new CommandBuyUnit(prices[unitID], units[unitID], position);
            ServiceLocator.Invoker.Execute(command);
        }
    }

    public void StartRound()
    {
        if (ServiceLocator.GameState.Phase == 1)
        {
            ServiceLocator.Broker.PubStart();
        }
    }
}
