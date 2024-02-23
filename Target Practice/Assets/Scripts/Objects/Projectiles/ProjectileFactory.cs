using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFactory<T> : MonoBehaviour where T : Projectile
{
    public GameObject Prefab;

    public T Summon(Vector2 position, GameObject target)
    {
        // Summon a projectile.
        GameObject product = Instantiate(Prefab, position, Quaternion.identity);
        T projectile = product.GetComponent<T>();

        // Make the projectile pursue the target
        projectile.Initialize(target);

        return projectile;
    }
}
