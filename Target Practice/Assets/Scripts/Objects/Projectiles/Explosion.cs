using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        List<Target> victims = ServiceLocator.QuadTree.Query(transform.position, 10.0f);
        foreach (Target victim in victims)
        {
            victim.TakeDamage(5);
        }
        StartCoroutine(disappear());
    }
    IEnumerator disappear()
    {
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
}
