using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class UnitManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] units;
    public float SpawnXRange = 5.0f;
    public float SpawnYRange = 5.0f;
    public float FirstSpawnTime = 2.0f;
    public float SpawnIntervalConst = 1.0f;
    public bool isSummoning = true;

    void Start()
    {
        InvokeRepeating("Spawn", FirstSpawnTime, SpawnIntervalConst);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    
    public void Spawn()
    {
        if (isSummoning)
        {
            Instantiate(units[UnityEngine.Random.Range(0, units.Length)], new Vector3(UnityEngine.Random.Range(-SpawnXRange, SpawnXRange), UnityEngine.Random.Range(-SpawnYRange, SpawnYRange), 0), Quaternion.identity);
        }
    }
}
