using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeService
{
    private string _typeJSONPath;
    private TargetType[] _types;
    public TargetType[] Types { get {return _types;}}

    public TypeService(string path) {
        this._typeJSONPath = path;
        string json = Resources.Load<TextAsset>(path).text;
        _types = JsonHelper.getJsonArray<TargetType>(json);
        foreach (TargetType type in _types) {
            Debug.Log(type);
            type.GetSprite();
        }
    }

    public TargetType GetRandomType() {
        return _types[Random.Range(0, _types.Length)];
    }
}
