using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBomb : Projectile
{ 
    public override void Initialize(Transform target) 
    {
        Aim(target);
        Move(15.0f);
        StartCoroutine(explode());
    }

    IEnumerator explode()
    {
        yield return new WaitForSeconds(0.6f);
        Instantiate(ServiceLocator.Instance.ExplosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
