using UnityEngine;

public class BotPlayer : Player
{
    private ElementManager elementManager;

    public BotPlayer(ElementManager elementManager) => this.elementManager = elementManager;

    public Element GetRandomElement()
    {
        return elementManager.allElements[UnityEngine.Random.Range(0, elementManager.allElements.Count)];
    }

    public override void OnTurnStarted()
    {
        SetCurrentElement(GetRandomElement());
        base.OnTurnStarted();
    }

    public override void OnTurnEnded()
    {
        base.OnTurnEnded();
    }
}