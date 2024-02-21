using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator : MonoBehaviour
{
    public string TypeJSONPath;
    public GameObject BulletPrefab;
    public GameObject BombPrefab;

    private static ServiceLocator _instance;
    public static ServiceLocator Instance { get { return _instance; } }

    public static Broker Broker { get; private set; }

    public static Invoker Invoker { get; private set; }

    public static TargetPool Pool { get; private set; }

    public static TypeService Types { get; private set; }

    public static ProjectileFactory<ProjectileBullet> BulletFactory { get; private set; }
    public static ProjectileFactory<ProjectileBomb> BombFactory { get; private set; }
    protected void Awake()
    {
        if (_instance != null && _instance != this) // singleton
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }

        Broker = new Broker();
        Invoker = new Invoker();
        Pool = gameObject.AddComponent<TargetPool>();
        Types = new TypeService(TypeJSONPath);
        BulletFactory = gameObject.AddComponent<ProjectileFactory<ProjectileBullet>>();
        BulletFactory.Prefab = BulletPrefab;
        BombFactory = gameObject.AddComponent<ProjectileFactory<ProjectileBomb>>();
        BombFactory.Prefab = BombPrefab;

    }

}
