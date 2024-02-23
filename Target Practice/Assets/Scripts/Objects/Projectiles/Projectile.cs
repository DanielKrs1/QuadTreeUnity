using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public abstract void Initialize(Transform target);

    void Aim(Transform target) {
        Transform.LookAt(target);
    }
}
