using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandBuyUnit : ICommand
{
    // PATTERN 8: COMMAND
    int price;
    GameObject prefab;
    Vector3 position;
    GameObject myUnit;
    public CommandBuyUnit(int price, GameObject prefab, Vector3 position)
    {
        Debug.Log("Buying " + prefab + "for $" + price + " at position " + position);
        this.price = price;
        this.prefab = prefab;
        this.position = position;
    }
    public void Execute()
    {
        if (ServiceLocator.GameState.SpendMoney(price))
        {
            myUnit = Object.Instantiate(prefab, position, Quaternion.identity);
        }

    }
    public void Undo()
    {
        if (myUnit != null)
        { 
            myUnit.GetComponent<Unit>().UnsubAll();
            Object.Destroy(myUnit);
            ServiceLocator.GameState.SpendMoney(-price);
        }
    }

}
