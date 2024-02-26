using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class UnitManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] units;
    public int[] prices;
    public float SpawnXRange = 5.0f;
    public float SpawnYRange = 5.0f;
    public float FirstSpawnTime = 2.0f;
    public float SpawnIntervalConst = 1.0f;
    public bool isSummoning = true;
    public Vector3 secondToLastClick;
    public Vector3 lastClick;
    public GameObject mainCamera;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            secondToLastClick = lastClick;
            lastClick = mainCamera.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
            lastClick.z = 0;

        }
    }

    public void BuyUnitAtLastClick(int unitID)
    {
        BuyUnit(unitID, secondToLastClick);
    }
    public void BuyUnit(int unitID, Vector3 inputPosititon) // TODO: Take a position parameter // Yep does that now
    {
        Vector3 position = new Vector3(UnityEngine.Random.Range(-SpawnXRange, SpawnXRange), UnityEngine.Random.Range(-SpawnYRange, SpawnYRange), 0);
        position = inputPosititon;
        if (isSummoning)
        {
            CommandBuyUnit command = new CommandBuyUnit(prices[unitID], units[unitID], position);    
            ServiceLocator.Invoker.Execute(command);
        }
    }
}
