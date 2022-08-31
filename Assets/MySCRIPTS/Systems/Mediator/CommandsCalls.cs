
class ScoreChangedCommand : ICommand
{
    public float ScoreOnTruck
    {
        get;
        set;
    }
    public float ScoreOnGlobal
    {
        get;
        set;
    } 
}
class DepositChangedCommand : ICommand
{
    public int BagsCuantity
    {
        get;
        set;
    }
    public bool OnDeposit
    {
        get;
        set;
    }
}