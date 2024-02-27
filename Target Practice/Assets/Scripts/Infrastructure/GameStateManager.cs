using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public int Round { get; private set; }
    public int Money { get; private set; }
    public int Score { get; private set; }
    public int Phase { get; private set; }

    public float TimeStart { get; private set; }

    float PointScaler(float t)
    { // Mysterious BS function to make kills worth more at the start of the round and in late rounds
        return Mathf.Pow(Phase,0.3f) * 2 / (Mathf.Log(Mathf.Pow(t,0.5f)+3.0f));
    }
    void OnDeath(Target t)
    {
        int reward = t.Type.Reward * (int)PointScaler(Time.time - TimeStart);
        Score += reward;
        Money += reward;
    }

    void OnEnd()
    {
        Round++;
        if (Round == 6) { Win(); }
        Phase = 1;
    }
    void OnStart()
    {
        Phase = 2;
        Score += Money;
        TimeStart = Time.time;
    }
    public bool SpendMoney(int m)
    {
        if (Money >= m)
        {
            Money -= m;
            return true;
        }
        else
        {
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
        Score = 0;
        ServiceLocator.Broker.SubDeath(OnDeath);
        ServiceLocator.Broker.SubEnd(OnEnd);
        ServiceLocator.Broker.SubStart(OnStart);
    }
}
