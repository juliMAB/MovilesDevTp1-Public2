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