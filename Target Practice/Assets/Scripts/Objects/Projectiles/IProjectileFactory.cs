using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectileFactory
{
    public Projectile Summon(Vector2 position, Transform target);
}
