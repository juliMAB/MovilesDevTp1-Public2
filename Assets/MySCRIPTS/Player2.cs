using UnityEngine;

public class Player2 : MonoBehaviour, Idownloadable
{
    [SerializeField] private float score;
    ScoreChangedCommand scoreChange = new ScoreChangedCommand();
    DepositChangedCommand depositChange = new DepositChangedCommand();
    [SerializeField] private Camera camera;

    [SerializeField] private Mediator mediator;

    [SerializeField] private Vector3 respawnPoint;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private int bolsasAmount = 0;

    private void Start()
    {
        respawnPoint = transform.position;
        mediator.Subscribe<DepositChangedCommand>(OutDeposit);
    }

    private void OnTriggerEnter(Collider other)
    {
        Ipickapeable ipickapeable = other.GetComponent<Ipickapeable>();
        if (ipickapeable!=null)
        {
            score = ipickapeable.Catch();
            scoreChange.ScoreOnTruck = score;
            mediator.Publish(scoreChange);
            bolsasAmount++;
            return;
        }
        Irespawneable irespawneable = other.GetComponent<Irespawneable>();
        if (irespawneable!=null)
        {
            respawnPoint = irespawneable.GetRespawnPoint();
        }
    }


    private void Respawn()
    {
        transform.position = respawnPoint;
        transform.rotation = Quaternion.identity;
        rb.velocity        = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void Update()
    {
        if (transform.position.y<-10)
        {
            Respawn();
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
        camera.gameObject.SetActive(false);
    }

    private void OutDeposit(DepositChangedCommand c)
    {
        if (c.OnDeposit)
            return;
        depositChange.OnDeposit = false;
        bolsasAmount = 0;
        camera.gameObject.SetActive(true);
        StartCar();
    }
}
