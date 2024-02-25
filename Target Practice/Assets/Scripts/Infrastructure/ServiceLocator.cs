using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator : MonoBehaviour
{ // PATTERN 2: SERVICE LOCATOR
    public string TypeJSONPath;
    public GameObject BulletPrefab;
    public GameObject BombPrefab;
    public GameObject TargetPrefab;

    private static ServiceLocator _instance;
    public static ServiceLocator Instance { get { return _instance; } }

    public static Broker Broker { get; private set; }

    public static Invoker Invoker { get; private set; }

    public static TargetPool Pool { get; private set; }

    public static TypeService Types { get; private set; }

    public static BulletFactory BulletFactory { get; private set; }
    public static BombFactory BombFactory { get; private set; }
    public static GameStateManager GameState { get; private set; }
    protected void Awake()
    {
        if (_instance != null && _instance != this) // PATTERN 1: SINGLETON
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }

        if (Broker == null) Broker = new Broker();
        if (Invoker == null) Invoker = new Invoker();
        if (Pool == null)
        {
            Pool = gameObject.AddComponent<TargetPool>();
            Pool.Prefab = TargetPrefab;
        }
        if (Types == null) Types = new TypeService(TypeJSONPath);
        if (BulletFactory == null)
        {
            BulletFactory = gameObject.AddComponent<BulletFactory>();
            BulletFactory.Prefab = BulletPrefab;
        }
        if (BombFactory == null)
        {
            BombFactory = gameObject.AddComponent<BombFactory>();
            BombFactory.Prefab = BombPrefab;
        }
        if (GameState == null) GameState = gameObject.AddComponent<GameStateManager>();

    }

}
