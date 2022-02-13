using System.Collections.Generic;

public class ElementManager
{
    public List<Element> allElements = new List<Element>();


    public ElementManager()
    {
        CreateElementRelations();
    }

    private void CreateElementRelations()
    {
        allElements.Add(new Element(new ELEMENTTYPE[] { ELEMENTTYPE.PAPER, ELEMENTTYPE.SPOCK }, new ELEMENTTYPE[] { ELEMENTTYPE.SCISSOR, ELEMENTTYPE.LIZARD }, ELEMENTTYPE.ROCK));
        allElements.Add(new Element(new ELEMENTTYPE[] { ELEMENTTYPE.SCISSOR, ELEMENTTYPE.LIZARD }, new ELEMENTTYPE[] { ELEMENTTYPE.ROCK, ELEMENTTYPE.SPOCK }, ELEMENTTYPE.PAPER));
        allElements.Add(new Element(new ELEMENTTYPE[] { ELEMENTTYPE.ROCK, ELEMENTTYPE.SPOCK }, new ELEMENTTYPE[] { ELEMENTTYPE.PAPER, ELEMENTTYPE.LIZARD }, ELEMENTTYPE.SCISSOR));
        allElements.Add(new Element(new ELEMENTTYPE[] { ELEMENTTYPE.SCISSOR, ELEMENTTYPE.ROCK }, new ELEMENTTYPE[] { ELEMENTTYPE.PAPER, ELEMENTTYPE.SPOCK }, ELEMENTTYPE.LIZARD));
        allElements.Add(new Element(new ELEMENTTYPE[] { ELEMENTTYPE.LIZARD, ELEMENTTYPE.PAPER }, new ELEMENTTYPE[] { ELEMENTTYPE.ROCK, ELEMENTTYPE.SCISSOR }, ELEMENTTYPE.SPOCK));
    }
}