public class Element
{
    public ELEMENTTYPE elementType;
    public ELEMENTTYPE[] canLoseTo;
    public ELEMENTTYPE[] canWinAgainst;

    public Element(ELEMENTTYPE[] canLoseTo, ELEMENTTYPE[] canWinAgainst, ELEMENTTYPE elementType)
    {
        this.canLoseTo = canLoseTo;
        this.canWinAgainst = canWinAgainst;
        this.elementType = elementType;
    }

    public ELEMENTTYPE GetCurrentElementType()
    {
        return elementType;
    }

    public ELEMENTTYPE[] GetLosingElements()
    {
        return this.canLoseTo;
    }

    public ELEMENTTYPE[] GetWinAgainstElements()
    {
        return this.canWinAgainst;
    }
}


public enum ELEMENTTYPE
{
    ROCK, PAPER, SCISSOR, LIZARD, SPOCK
}
