
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

class SceneChangedCommand : ICommand
{
    /// <summary>
    /// 0=intro,1=Game,2=Deposit
    /// </summary>
    public int OnGoIndex
    {
        get;
        set;
    }
}