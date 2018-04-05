using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseNode : MonoBehaviour {
    public UIManager _uiManager;
    private Bee _bee;
    public int _health;
    
    public int maxQuota;
    private int soldierBeeCost;
    private int workerBeeCost;
    private List<GameObject> _resourceList;



    //Arda
    private PlayerManager playerManager; //player manager class ref

    public int playerResource; //how many resource this base have
    public string baseOwner; //who is the owner of this base

    private int _soldierBeeResourceCost;
    private int _workerBeeResourceCost;
    private int _soldierBeeQuotaCost;
    private int _workerBeeQuotaCost;

    private int _maxBeeQuota;

    private void Awake()
    {
        _bee = GetComponent<Bee>();
        _uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();

        //set player manager ref
        playerManager = GameManager.Instance.GetComponent<PlayerManager>();

        //set base owner
        if (playerManager.base_P1 == this.gameObject)
        {
            baseOwner = "Player1";
        }
        else if (playerManager.base_P2 == this.gameObject)
        {
            baseOwner = "Player2";
        }

        //set Costs
        _soldierBeeResourceCost = GameManager.Instance.soldierBeeResourceCost;
        _workerBeeResourceCost = GameManager.Instance.workerBeeResourceCost;
        _soldierBeeQuotaCost = GameManager.Instance.soldierBeeQuotaCost;
        _workerBeeQuotaCost = GameManager.Instance.workerBeeQuotaCost;

        //set max bee quota
        _maxBeeQuota = GameManager.Instance.maxBeeQuota;

        

    }

    void Start()
    {
        //Increasing _honeyStock 5 per second.
        InvokeRepeating("AddHoneyStock", 1, 1);
    }

    void Update()
    {

    }

    public void CreateSoldierBee()
    {
        if (playerResource >= _soldierBeeResourceCost && playerManager.concurrentBee_P1 < maxQuota) // kimden uretiyor ona gore check et
        {
            playerResource -= soldierBeeCost;
            _bee.SetSoldierBeeNumber(_bee.GetSoldierBeeNumber() + 1);
            _bee.SetQuota(_bee.GetQuota() + 1);
        }
        else { Debug.Log("Soldier creation error;");}
    }

    public void CreateWorkerBee()
    {
        if (playerResource >= workerBeeCost && _bee.GetQuota() < maxQuota)
        {
            playerResource -= workerBeeCost;
            _bee.SetWorkerBeeNumber(_bee.GetWorkerBeeNumber() + 1);
            _bee.SetQuota(_bee.GetQuota() + 1);
        }
        else { Debug.Log("Worker creation error;"); }

    }

    private void AddHoneyStock()
    {
        Debug.Log("Adding honey stock:" + playerResource);
        playerResource += 5;
    }

    //Need to now who has how many bees in a particular resource.
    //Worker and Soldier bees need to be an object with an attribute to keep track of the owner of them...
    private void AddHoneyStockWithWorkerBee()
    {
        _resourceList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Resource"));
        foreach(var go in _resourceList)
        {
            Debug.Log("Working forEach");
            //go.GetComponent<>
        }
    }

    private void OnMouseDown()
    {
        _uiManager.Highlight(gameObject);
    }


}
