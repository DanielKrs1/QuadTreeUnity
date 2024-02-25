using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] public class TargetType
{ // PATTERN 9: TYPE OBJECT
    public string SpritePath;
    public int MaxHealth;
    public int Reward;
    public float Size;
    public Sprite Sprite;
    public void GetSprite() {
        Sprite = Resources.Load<Sprite>(SpritePath);
    }
}
