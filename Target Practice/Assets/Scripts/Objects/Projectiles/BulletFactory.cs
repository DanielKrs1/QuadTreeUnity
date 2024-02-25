using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : MonoBehaviour, IProjectileFactory
{ // PATTERN 7: FACTORY
    public GameObject Prefab;

    public Projectile Summon(Vector3 position, Transform target)
    {
        // Summon a projectile.
        GameObject product = Instantiate(Prefab, position, Quaternion.identity);
        ProjectileBullet projectile = product.GetComponent<ProjectileBullet>();

        // Make the projectile pursue the target
        projectile.Initialize(target);

        return projectile;
    }
}
