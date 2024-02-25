using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private static CameraManager _instance;
    public static CameraManager Instance { get {return _instance;}}

    protected void Awake() 
    {
        if (_instance != null && _instance != this) // PATTERN 1: SINGLETON
        {
            Destroy(this);
        } 
        else
        {
            _instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
