using System;
using UnityEngine;

public class Player
{
    private Element currentElement;
    public Action<Element> onElementSelected;
    public Action onTurnEnded;

    public void SetCurrentElement(Element selectedType)
    {
        currentElement = selectedType;
        onElementSelected?.Invoke(currentElement);
        OnTurnEnded();
    }

    public Element GetCurrentElement()
    {
        return currentElement;
    }

    public virtual void OnTurnStarted()
    {
        //Turn started
    }

    public virtual void OnTurnEnded()
    {
       onTurnEnded?.Invoke();
    }
}