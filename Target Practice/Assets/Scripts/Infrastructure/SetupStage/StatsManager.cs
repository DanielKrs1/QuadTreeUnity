using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    // Start is called before the first frame update

    public int money;
    public int score;
    public int round;
    public int phase;
    void Start()
    {
        money = 100;
        score = 0;
        round = 1;
        phase = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
