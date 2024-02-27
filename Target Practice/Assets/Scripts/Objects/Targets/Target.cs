using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public TargetType Type; 
    public int CurHealth; 
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
        ServiceLocator.QuadTree.Remove(this);
        transform.position = new Vector3(-500,-500,0);
        ServiceLocator.Broker.PubDeath(this);
        gameObject.SetActive(false);
        IsDead = true;
    }
    public void Initialize()
    {
        Type = ServiceLocator.Types.GetRandomType();
        CurHealth = Type.MaxHealth;
        IsDead = false;
        transform.position = new Vector3(Random.Range(0f, 300f), Random.Range(0f, 200f), 0);
        transform.localScale = new Vector3(Type.Size, Type.Size, Type.Size) * 20;
        gameObject.GetComponent<SpriteRenderer>().sprite = Type.Sprite;
        ServiceLocator.QuadTree.Add(this);
        gameObject.SetActive(true);

    }

    public void Awake() 
    {
        IsDead = true;
        gameObject.SetActive(false);
    }

}
