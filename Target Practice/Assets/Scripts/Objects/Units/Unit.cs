using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    // TODO: Figure something out with Behaviour.enabled to make onStart and onEnd work
    // (obv need to subscribe to start and end)

    public Vector2 OriginalPos { get; set; }

    private float _nextActionTime = 0.0f;
    private Target _curTarget;

    // CHANGE THIS IN SUBCLASSES
    private ProjectileFactory _fact;
    private float _cooldown;
    abstract void Move();
    abstract Target SelectTarget();

    void Start()
    {
        ServiceLocator.Broker.SubStart(OnStart);
        ServiceLocator.Broker.SubEnd(OnEnd);
    }
    public void OnEnd()
    {
        Transform.position = OriginalPos;
        this.enabled = false;
    }

    public void OnStart()
    {
        this.enabled = true;
        _nextActionTime = Time.time;
    }

    protected void Fire(Target target)
    {
        _fact.Summon(Transform.position, target.Transform);
    }

    protected Target FindNearest()
    {
        // TODO
    }

    void Update()
    {
        Move();
        if (Time.time > _nextActionTime)
        {
            _nextActionTime += _cooldown;
            Target target = SelectTarget();
            Fire(target);
        }
    }
}
