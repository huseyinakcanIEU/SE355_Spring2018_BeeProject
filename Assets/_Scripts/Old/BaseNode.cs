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

    public int currentBaseResource; //how many resource this base have
    //public string baseOwner; //who is the owner of this base
    Player baseOwner;

    public GameObject soldierBeePrefab;
    public GameObject workerBeePrefab;

    private int _soldierBeeResourceCost;
    private int _workerBeeResourceCost;
    private int _soldierBeeQuotaCost;
    private int _workerBeeQuotaCost;

    private int _maxBeeQuota;

    private List<Transform> spawnPositions = new List<Transform>(); //bee spawn positions (you cant create empty transform! use vector3)

    enum Player
    {
        P1,
        P2,
    }

    private void Awake()
    {
        _bee = GetComponent<Bee>();
        _uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();

        //set player manager ref
        playerManager = GameManager.Instance.GetComponent<PlayerManager>();

        //set base owner
        if (playerManager.base_P1 == this.gameObject)
        {
            baseOwner = Player.P1;
        }
        else if (playerManager.base_P2 == this.gameObject)
        {
            baseOwner = Player.P2;
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

        //add all spawn pos transforms to spawnPos list
        //var tempChildren = gameObject.GetComponentsInChildren<Vector3>();

        var tempTransformOfChildren = gameObject.GetComponentsInChildren<Transform>();
        //tempTransformOfChildren = gameObject.GetComponentsInChildren<Transform>();
        foreach (var child in tempTransformOfChildren)
        {
            if (child.CompareTag("BeeSpawnPos") == true)
            {
                spawnPositions.Add(child);
            }
        }
    }

    void Update()
    {

    }

    public void CreateSoldierBee()
    {
        
        if (baseOwner == Player.P1)
        {
            
            if (currentBaseResource >= _soldierBeeResourceCost && playerManager.concurrentBee_P1 < _maxBeeQuota)
            {
                currentBaseResource = currentBaseResource - _soldierBeeResourceCost; //decrease resource cost from total
                playerManager.concurrentBee_P1 = playerManager.concurrentBee_P1 + 1; //update p1 concurrent bee

                //spawn pos fixed listenin ilk elemani degil de duzgun bir mantik ile hangi noktada spawn edecegine karar vermeli(arilar ust uste binmesin, yazik gunah)
                GameObject tempObj = Instantiate(soldierBeePrefab,spawnPositions[0].position,Quaternion.identity); //instantiate a bee from base player 1

                tempObj.transform.parent = playerManager.beePool_P1.transform; //transport this bee into pool (cumburlop, gluk gluk gluk...)
            }
            else
            {
                Debug.Log("CantCreateSoldier P1-> " + "CurrRes=" + currentBaseResource + ">" + "soldierCost= " + _soldierBeeResourceCost + "&&" + " " + "P1concurrBee= " + playerManager.concurrentBee_P1 + "<" + "MaxBeeQuota= " + _maxBeeQuota);
            }
        }
        else if (baseOwner == Player.P2)
        {
            if (currentBaseResource >= _soldierBeeResourceCost && playerManager.concurrentBee_P2 < _maxBeeQuota)
            {
                currentBaseResource = currentBaseResource - _soldierBeeResourceCost; //decrease resource cost from total
                playerManager.concurrentBee_P2 = playerManager.concurrentBee_P2 + 1; //update p1 concurrent bee

                GameObject tempObj = Instantiate(soldierBeePrefab, spawnPositions[0].position, Quaternion.identity); //instantiate a bee from base player 1
                tempObj.transform.parent = playerManager.beePool_P2.transform; //transport this bee into pool (cumburlop, gluk gluk gluk...)
                //Debug.Log("WALLLLLDOOOOOOOO!!");
            }
            else
            {
                Debug.Log("CantCreateSoldier P2-> " + "CurrRes=" + currentBaseResource + ">" + "soldierCost= " + _soldierBeeResourceCost + " && " + "P1concurrBee= " + playerManager.concurrentBee_P1 + "<" + "MaxBeeQuota= " + _maxBeeQuota);
            }
        }
        else
        {
            Debug.LogWarning("Player settings may wrong. Check P1 and P2 settings or mailto: ardazeytin@outlook.com");
        }

    }

    public void CreateWorkerBee()
    {
        //if (currentBaseResource >= workerBeeCost && _bee.GetQuota() < maxQuota)
        //{
        //    currentBaseResource -= workerBeeCost;
        //    _bee.SetWorkerBeeNumber(_bee.GetWorkerBeeNumber() + 1);
        //    _bee.SetQuota(_bee.GetQuota() + 1);
        //}
        //else { Debug.Log("Worker creation error;"); }

    }


    //standart resource gathering without using resource node
    private void AddHoneyStock()
    {
        Debug.Log("Base " + baseOwner +" resource= "+ currentBaseResource);
        currentBaseResource += 5;
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
