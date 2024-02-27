using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    // PATTERN 5: SUBCLASS SANDBOX
    public abstract void Initialize(Transform target);

    protected Vector3 NormDir(Transform target) {
        Vector3 diff = target.position - transform.position;
        return Vector3.Normalize(diff);
    }
    protected void Aim(Transform target) {
        Vector3 diff = NormDir(target);
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }

    protected void Hurt(GameObject target, int damage) {
        target.GetComponent<Target>().TakeDamage(damage);
    }

    protected void Move(float speed) {
        GetComponent<Rigidbody>().AddForce(transform.up * speed, ForceMode.Impulse);
    }
}
