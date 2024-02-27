using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    // TODO: Figure something out with Behaviour.enabled to make onStart and onEnd work
    // (obv need to subscribe to start and end)
    public GameStateManager gameState;
    
    public Vector3 OriginalPos { get; set; }


    protected float _nextActionTime = 0.0f;
    protected Target _curTarget;

    // CHANGE THIS IN SUBCLASSES - PATTERN 5: SUBCLASS SANDBOX
    protected IProjectileFactory _fact {get; set;}
    public float Cooldown {get; set;}
    protected abstract void Init();
    protected abstract void Move();
    protected abstract void DoOnCooldown();
    void Start()
    {
        OriginalPos = transform.position;
        ServiceLocator.Broker.SubStart(OnStart);
        ServiceLocator.Broker.SubEnd(OnEnd);
        gameState = ServiceLocator.GameState;
    }
    public void OnEnd()
    {
        transform.position = OriginalPos;
        this.enabled = false;
    }

    public void OnStart()
    {
        Init();
        this.enabled = true;
        _nextActionTime = Time.time;
    }

    public void UnsubAll()
    {
        ServiceLocator.Broker.UnsubStart(OnStart);
        ServiceLocator.Broker.UnsubEnd(OnEnd);
    }
    protected void Fire(Target target)
    {
        _fact.Summon(transform.position, target.transform);
    }

    protected Target FindNearest()
    {
        // TODO
        return null;
    }

    void Update()
    {
        Move();
        if (Time.time > _nextActionTime)
        {
            _nextActionTime += Cooldown;
            DoOnCooldown();
        }
    }
}
