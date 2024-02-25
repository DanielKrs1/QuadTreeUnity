using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class WinScreen : MonoBehaviour
{
    public int score;
    TMP_Text winText;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.activeSceneChanged += ChangedScene;
    }

    void ChangedScene(Scene current, Scene next) {
        if (next.name == "WinScene") {
            winText = GameObject.Find("WinText").GetComponent<TMP_Text>();
            winText.text = "Your score was: "+ score;
        }
    }

    void PlayAgain()
    {
        SceneManager.LoadScene("GameScene");
        Destroy(this.gameObject);
    }
}
