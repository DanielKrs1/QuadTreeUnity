using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public int Round {get; private set;}
    public int Money {get; private set;}
    public int Score {get; private set;}
    public int Phase {get; private set;}

    void OnDeath(Target t) {
        // TODO: Scale with time
        Score += t.Type.Reward; 
        Money += t.Type.Reward;
    }

    void OnEnd() {
        Round++;
        if (Round == 6) { Win();}
        Phase = 1;
    }
    void OnStart() {
        Phase = 0;
    }
    public bool SpendMoney(int m) {
        if (Money >= m) {
            Money -= m;
            return true;
        } else {
            return false;
        }

    }

    void Win() 
    { // Instantiate a temporary object for the win screen
        GameObject winObj = new GameObject("Win Screen");
        winObj.AddComponent<WinScreen>();
        winObj.GetComponent<WinScreen>().score = Score;
        SceneManager.LoadScene("WinScene");
    }
    // Start is called before the first frame update
    void Start()
    {
        Money = 1000;
        Phase = 1; // buy
        Round = 1;
        ServiceLocator.Broker.SubDeath(OnDeath);
        ServiceLocator.Broker.SubEnd(OnEnd);
        ServiceLocator.Broker.SubStart(OnStart);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
