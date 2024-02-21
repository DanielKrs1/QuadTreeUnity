using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    private static TargetManager _instance;
    public static TargetManager Instance { get {return _instance;}}

    protected void Awake() 
    {
        if (_instance != null && _instance != this) // singleton
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

    // TODO: When round starts, spawn and shuffle around the targets
}
