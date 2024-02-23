using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombFactory : MonoBehaviour, IProjectileFactory
{
    public GameObject Prefab;

    public Projectile Summon(Vector2 position, Transform target)
    {
        // Summon a projectile.
        GameObject product = Instantiate(Prefab, position, Quaternion.identity);
        ProjectileBomb projectile = product.GetComponent<ProjectileBomb>();

        // Make the projectile pursue the target
        projectile.Initialize(target);

        return projectile;
    }
}
