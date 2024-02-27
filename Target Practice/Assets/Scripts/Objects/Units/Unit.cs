using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public GameStateManager gameState;

    public Vector3 OriginalPos { get; set; }


    protected float _nextActionTime = 0.0f;
    public Target _curTarget;

    // CHANGE THIS IN SUBCLASSES - PATTERN 5: SUBCLASS SANDBOX
    protected IProjectileFactory _fact { get; set; }
    public float Cooldown { get; set; }
    protected abstract void Init();
    protected abstract void Move();
    protected abstract void DoOnCooldown();
    void Start()
    {
        OriginalPos = transform.position;
        ServiceLocator.Broker.SubStart(OnStart);
        ServiceLocator.Broker.SubEnd(OnEnd);
        gameState = ServiceLocator.GameState;
        this.enabled = false;
    }
    public void OnEnd()
    {
        transform.position = OriginalPos;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        this.enabled = false;
    }

    public void OnStart()
    {
        Init();
        this.enabled = true;
        _nextActionTime = Time.time - 1;
    }

    public void UnsubAll()
    {
        ServiceLocator.Broker.UnsubStart(OnStart);
        ServiceLocator.Broker.UnsubEnd(OnEnd);
    }
    protected void Fire(Target target)
    {
        Fire(target.transform);
    }

    protected void Fire(Transform target)
    {
        _fact.Summon(transform.position, target);
    }


    protected Vector3 NormDir(Vector3 target)
    {
        Vector3 diff = target - transform.position;
        return Vector3.Normalize(diff);
    }

    protected Vector3 NormDir(Target target)
    {
        return NormDir(target.transform.position);
    }
    protected void Aim(Vector3 target)
    {
        Vector3 diff = NormDir(target);
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }
    protected void Aim(Transform target)
    {
        Aim(target.position);
    }

    protected Target strongestWithinRange(float range)
    {
        List<Target> _targets = ServiceLocator.QuadTree.Query(transform.position, range);
        if (_targets.Count == 0)
        {
            return ServiceLocator.Pool.RandomAliveTarget();
        }
        Target strongest = _targets[0];
        for (int i = 0; i < _targets.Count; i++)
        {
            if (!_targets[i].IsDead)
            {
                if (_targets[i].CurHealth > strongest.CurHealth || (_targets[i].CurHealth == strongest.CurHealth && Vector3.Distance(transform.position, _targets[i].transform.position) < Vector3.Distance(transform.position, strongest.transform.position)))
                {
                    strongest = _targets[i];
                }
            }
        }
        return strongest;
    }

    void Update()
    {
        Move();
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        if (transform.position.x < 0 || transform.position.x > 300 || transform.position.y < 0 || transform.position.y > 200)
        {
            if (_curTarget != null) Aim(_curTarget.transform);
        }
        if (Time.time > _nextActionTime)
        {
            _nextActionTime += Cooldown;
            DoOnCooldown();
        }
    }
}
