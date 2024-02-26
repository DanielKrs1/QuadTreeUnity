using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DisplayScoreAtEnd : MonoBehaviour
{
    public TMP_Text scoreText;
    public GameObject winObj;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        winObj = GameObject.Find("Win Screen");
        
        scoreText.text = "Score: " + winObj.GetComponent<WinScreen>().score;
    }
}
