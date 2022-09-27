
class ScoreChangedCommand : ICommand
{
    public int BagsOnTruck
    {
        get;
        set;
    }
    public int ScoreOnGlobal
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
    /// <summary>
    /// 0=one,1=two,2=both
    /// </summary>
    public int pjIndex
    {
        get;
        set;
    }
}