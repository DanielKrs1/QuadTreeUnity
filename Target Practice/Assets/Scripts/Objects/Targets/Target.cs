using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // TODO: Actually do things, look up type object
    public int ID; // For the object pool to easily find it when it dies
    public TargetType Type;
    public double CurHealth; // TODO: Set to max health on instantiation

    public void TakeDamage(double damage)
    {
        CurHealth -= damage;
        if (CurHealth <= 0)
        {
            CurHealth = 0;
            Die();
        }
    }
    public void Die()
    {
        ServiceLocator.Broker.PubDeath(this);
        gameObject.SetActive(false);
    }
    public void Initialize()
    {
        CurHealth = Type.MaxHealth;
        // TODO: Go to random position

    }
}
