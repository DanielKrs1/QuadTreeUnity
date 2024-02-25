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
    public GameStateManager gameState;
    void Start()
    {
        gameState = ServiceLocator.GameState;
        moneyText = GameObject.Find("MoneyText").GetComponent<TMP_Text>();
        scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
        roundText = GameObject.Find("RoundNumberText").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "Money: "+ gameState.Money;
        scoreText.text = "Score: " + gameState.Score;
        roundText.text = "Round " + gameState.Round;
        if (gameState.Phase == 1)
        {
            roundText.text += "\nBUY PHASE";
        }
        else
        {
            roundText.text += "\nPLAY PHASE";
        }
       
    }
}
