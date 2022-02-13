using UnityEngine;

public class RealPlayer : Player
{
    public override void OnTurnStarted()
    {
        Debug.LogError("Player turn started" + this);
        base.OnTurnStarted();
    }

    public override void OnTurnEnded()
    {
        Debug.LogError("Player turn ended" + this);
        base.OnTurnEnded();
    }

}