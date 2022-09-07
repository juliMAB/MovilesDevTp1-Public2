using UnityEngine;

public class Player2 : MonoBehaviour, Idownloadable
{
    private ScoreChangedCommand scoreChange = new ScoreChangedCommand();
    private DepositChangedCommand depositChange = new DepositChangedCommand();
    private SceneChangedCommand sceneChanged = new SceneChangedCommand();

    [SerializeField] private Mediator mediator;

    
    [SerializeField] private Rigidbody rb;

    [SerializeField] private int bolsasAmount = 0;

    private void Start()
    {
        
        mediator.Subscribe<DepositChangedCommand>(OutDeposit);
        mediator.Subscribe<ScoreChangedCommand>(GetActualScoreTruck);
    }

    private void GetActualScoreTruck(ScoreChangedCommand c)
    {
        scoreChange.ScoreOnTruck = c.ScoreOnTruck;
    }

    private void OnTriggerEnter(Collider other)
    {
        Ipickapeable ipickapeable = other.GetComponent<Ipickapeable>();
        if (ipickapeable!=null)
        {
            if (bolsasAmount == 3)
                return;
            scoreChange.ScoreOnTruck += ipickapeable.Catch();
            mediator.Publish(scoreChange);
            bolsasAmount++;
            return;
        }
    }

    public bool HasBags()
    {
        return bolsasAmount>0;
    }

    public void StopCar()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }
    private void StartCar()
    {
        rb.constraints = RigidbodyConstraints.None;
    }

    public void IntroDeposit()
    {
        depositChange.BagsCuantity = bolsasAmount;
        depositChange.OnDeposit = true;
        mediator.Publish(depositChange);
        sceneChanged.OnGoIndex = 2;
        mediator.Publish(sceneChanged);
    }

    private void OutDeposit(DepositChangedCommand c)
    {
        if (c.OnDeposit)
            return;
        depositChange.OnDeposit = false;
        bolsasAmount = 0;
        sceneChanged.OnGoIndex = 1;
        mediator.Publish(sceneChanged);
        StartCar();
    }
}
