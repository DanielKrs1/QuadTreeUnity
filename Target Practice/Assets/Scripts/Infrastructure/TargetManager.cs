using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public int[] TargetCount;
    private static TargetManager _instance;
    public static TargetManager Instance { get {return _instance;}}

    protected void Awake() 
    { // PATTERN 1: SINGLETON
        if (_instance != null && _instance != this) 
        {
            Destroy(this);
        } 
        else
        {
            _instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        ServiceLocator.Broker.SubStart(OnStart);
    }

    void OnStart() 
    {
        int roundIdx = ServiceLocator.GameState.Round - 1;
        ServiceLocator.Pool.SummonTargets(TargetCount[roundIdx]);
    }

}
