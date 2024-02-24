using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsDisplayer : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text moneyText;
    public TMP_Text scoreText;
    public TMP_Text roundText;
    public StatsManager statsManager;
    void Start()
    {
        
        moneyText = GameObject.Find("MoneyText").GetComponent<TMP_Text>();
        scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
        roundText = GameObject.Find("RoundNumberText").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "Money: "+statsManager.money;
        scoreText.text = "Score: " + statsManager.score;
        roundText.text = "Round " + statsManager.round;
        if (statsManager.phase == 1)
        {
            roundText.text += "\nBUY PHASE";
        }
        else
        {
            roundText.text += "\nPLAY PHASE";
        }
       
    }
}
