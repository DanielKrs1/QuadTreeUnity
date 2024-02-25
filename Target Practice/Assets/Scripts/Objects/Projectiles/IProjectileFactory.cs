using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectileFactory
{  // PATTERN 7: FACTORY
    public Projectile Summon(Vector3 position, Transform target);
}
