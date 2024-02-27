using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // TODO: Actually do things, look up type object
    public int ID; // For the object pool to easily find it when it dies
    public TargetType Type; // PATTERN 9: TYPE OBJECT
    public int CurHealth; // TODO: Set to max health on instantiation
    public bool IsDead;

    public void TakeDamage(int damage)
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
        IsDead = true;
    }
    public void Initialize()
    {
        Type = ServiceLocator.Types.GetRandomType();
        CurHealth = Type.MaxHealth;
        IsDead = false;
        // TODO: Go to random position
        // TODO: Scale object to size based on Type.Size
        // TODO: Set sprite based on Type.Sprite

        gameObject.SetActive(true);

    }

    public void Awake() 
    {
        IsDead = true;
        gameObject.SetActive(false);
    }
}
