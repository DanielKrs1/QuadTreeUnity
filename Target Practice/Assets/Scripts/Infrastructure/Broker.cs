using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broker
{

    public delegate void TargetDeath(Target target);
    private TargetDeath SendDeath;

    public void PubDeath(Target m)
    {
        SendDeath(m);
    }

    public void SubDeath(TargetDeath method)
    {
        SendDeath += method;
    }

    public void UnsubDeath(TargetDeath method)
    {
        SendDeath -= method;
    }

    public delegate void RoundEnd();
    private RoundEnd SendEnd;

    public void PubEnd()
    {
        SendEnd();
    }

    public void SubEnd(RoundEnd method)
    {
        SendEnd += method;
    }

    public void UnsubEnd(RoundEnd method)
    {
        SendEnd -= method;
    }

    public delegate void RoundStart();
    private RoundStart SendStart;

    public void PubStart()
    {
        SendStart();
    }

    public void SubStart(RoundStart method)
    {
        SendStart += method;
    }

    public void UnsubStart(RoundStart method)
    {
        SendStart -= method;
    }
}
