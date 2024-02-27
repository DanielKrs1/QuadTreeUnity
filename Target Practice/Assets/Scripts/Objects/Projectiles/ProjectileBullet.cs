using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBullet : Projectile
{ 
    public override void Initialize(Transform target)
    {
        Aim(target);
        Move(55.0f);
    }

    void OnTriggerEnter(Collider other)
    {
        Target target = other.gameObject.GetComponent<Target>();
        if (target != null)
        {
            target.TakeDamage(2);
            Destroy(gameObject);
        }
    }

}
