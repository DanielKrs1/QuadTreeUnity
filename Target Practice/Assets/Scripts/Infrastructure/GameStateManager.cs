using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public int Round;
    public int Money;
    public int Score;

    void OnDeath(Target t) {
        // TODO: Scale with time
        Score += t.Type.Reward; 
        Money += t.Type.Reward;
    }

    void OnEnd() {
        Round++;
    }

    public void SpendMoney(int m) {
        Money -= m;
    }

// TODO: Keep track of round, money, etc. Subscribe to death, roundstart, roundend

    // Start is called before the first frame update
    void Start()
    {
        Round = 1;
        ServiceLocator.Broker.SubDeath(OnDeath);
        ServiceLocator.Broker.SubEnd(OnEnd);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
