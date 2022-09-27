using UnityEngine;

public class Player2 : MonoBehaviour, Idownloadable
{
    #region EXPOSED_FIELD
    [SerializeField] private Mediator mediator;

    [SerializeField] private PjIndex id;
    #endregion

    #region PRIVATE_FIELD
    private ScoreChangedCommand scoreChange = new ScoreChangedCommand();
    private SceneChangedCommand sceneChanged = new SceneChangedCommand();
    
    private Rigidbody rb;
    #endregion

    #region UNITY_CALLS
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        mediator.Subscribe<SceneChangedCommand>(OutDeposit);
    }
    private void OnTriggerEnter(Collider other)
    {
        Ipickapeable ipickapeable = other.GetComponent<Ipickapeable>();
        if (ipickapeable!=null)
        {
            if (scoreChange.BagsOnTruck == 3)
                return;
            scoreChange.BagsOnTruck += ipickapeable.Catch();
            scoreChange.ScoreOnGlobal += MyGameplayManager.BagValue;
            mediator.Publish(scoreChange);
            return;
        }
    }
    #endregion

    #region PUBLIC_METHODS

    public bool HasBags()
    {
        return scoreChange.BagsOnTruck > 0;
    }
    public void IntroDeposit()
    {
        StopCar();
        sceneChanged.OnGoIndex = (int)GameStage.Deposit;
        sceneChanged.pjIndex = (int)id;
        mediator.Publish(sceneChanged);
    }
    #endregion

    #region PRIVATE_METHODS
    private void StopCar()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }
    private void StartCar()
    {
        rb.constraints = RigidbodyConstraints.None;
    }

    private void OutDeposit(SceneChangedCommand c)
    {
        if (c.OnGoIndex != (int)GameStage.Game)
            return;
        StartCar();
    }
    #endregion

}