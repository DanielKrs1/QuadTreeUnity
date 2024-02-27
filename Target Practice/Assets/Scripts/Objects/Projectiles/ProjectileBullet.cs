using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBullet : Projectile
{ 
    public override void Initialize(Transform target)
    {
        Aim(target);
        Move(25.0f);
    }

    void OnTriggerEnter(Collider other)
    {
        Target target = other.gameObject.GetComponent<Target>();
        if (target != null)
        {
            target.TakeDamage(3);
            Destroy(gameObject);
        }
    }

}
