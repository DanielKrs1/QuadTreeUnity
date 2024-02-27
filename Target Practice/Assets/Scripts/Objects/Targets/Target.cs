using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // TODO: Actually do things, look up type object
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
        transform.position = new Vector3(Random.Range(0f, 300f), Random.Range(0f, 200f), -1);
        transform.localScale = new Vector3(Type.Size, Type.Size, Type.Size) * 20;
        gameObject.GetComponent<SpriteRenderer>().sprite = Type.Sprite;

        gameObject.SetActive(true);

    }

    public void Awake() 
    {
        IsDead = true;
        gameObject.SetActive(false);
    }

}
