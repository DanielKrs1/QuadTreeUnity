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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    
    public void BuyUnit(int unitID) // TODO: Take a position parameter
    {
        Vector3 position = new Vector3(UnityEngine.Random.Range(-SpawnXRange, SpawnXRange), UnityEngine.Random.Range(-SpawnYRange, SpawnYRange), 0);
        if (isSummoning)
        {
            CommandBuyUnit command = new CommandBuyUnit(prices[unitID], units[unitID], position);    
            ServiceLocator.Invoker.Execute(command);
        }
    }
}
