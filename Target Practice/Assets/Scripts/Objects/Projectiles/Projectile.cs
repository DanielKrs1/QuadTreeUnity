using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    // PATTERN 5: SUBCLASS SANDBOX
    public abstract void Initialize(Transform target);

    protected void Aim(Transform target) {
        transform.LookAt(target);
    }

    protected void Hurt(GameObject target, int damage) {
        target.GetComponent<Target>().TakeDamage(damage);
    }
}
