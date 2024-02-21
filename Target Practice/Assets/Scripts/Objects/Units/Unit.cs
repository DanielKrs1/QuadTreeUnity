using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    // TODO: Figure something out with Behaviour.enabled to make onStart and onEnd work
    // (obv need to subscribe to start and end)

    public IUnitStrategy Strategy { get; set; }
    public Vector2 OriginalPos { get; set; }

    // Maybe a unit only has one target, and only changes it after it dies? IDK
    // The main actions of a unit are moving and firing (calling one of the factories)

    void OnEnd()
    {
        // TODO: Teleport to original position and stop updating
        // Subscribe to round end with this function
        this.enabled = false;
    }

    void OnStart()
    {
        this.enabled = true;
    }

}
