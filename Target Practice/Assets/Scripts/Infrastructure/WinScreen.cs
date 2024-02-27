using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class WinScreen : MonoBehaviour
{
    public int score;
    TextMeshProUGUI winText;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += ChangedScene;
    }

    void ChangedScene(Scene next, LoadSceneMode mode) {
        if (next.name == "GameScene") {
            SceneManager.sceneLoaded -= ChangedScene;           
            Destroy(this.gameObject);
        }
    }

    void PlayAgain()
    {
        SceneManager.LoadScene("GameScene");
    }
}
