using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnitBomber : Unit
{
    
    protected override void Init()
    {
        _fact = ServiceLocator.BombFactory;
        Cooldown = 3000;
        
        Debug.Log("huh");
    }
    protected override void DoOnCooldown()
    {
        
    }
    
    protected override void Move()
    {
        if (gameState.Phase == 2)
        {
            transform.Translate(Vector3.right * Time.deltaTime * Random.Range(0, 100));
            transform.Translate(Vector3.up * Time.deltaTime * Random.Range(0, 100));
            transform.Translate(Vector3.left * Time.deltaTime * Random.Range(0, 100));
            transform.Translate(Vector3.down * Time.deltaTime * Random.Range(0, 100));
        }

    }
}
