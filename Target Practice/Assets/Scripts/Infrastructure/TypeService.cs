using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeService
{
    private string _typeJSONPath;
    private List<TargetType> _types;
    public List<TargetType> Types { get {return _types;}}

    public TypeService(string path) {
        this._typeJSONPath = path;
        // TODO: deserialize JSON and create an object for each type
    }
}
