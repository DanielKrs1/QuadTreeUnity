using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowStrategyPanel : MonoBehaviour
{

    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        panel = GameObject.Find("UICanvas");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            panel.SetActive(!panel.activeSelf);
        }
       
    }
}
