using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseNode : MonoBehaviour {
    public UIManager _uiManager;
    public int healthOfBase; //kralice ari icin gecici sanirim(test)
    


    //Arda: usttekki prop.ler eski alttakiler yeni 06:43AM

    private PlayerManager playerManager; //player manager class ref

    public int currentBaseResource; //how many resource this base have
    Player baseOwner; //enum P1 P2

    //bee prefabs
    public GameObject soldierBeePrefab;
    public GameObject workerBeePrefab;

    //costs and quotas
    private int _soldierBeeResourceCost;
    private int _workerBeeResourceCost;
    private int _soldierBeeQuotaCost;
    private int _workerBeeQuotaCost;
    private int _maxBeeQuota;

    private List<Transform> spawnPositions = new List<Transform>(); //bee spawn positions (you cant create empty transform! use vector3)

    public int concurrentSoldierBee = 0; //base de kac tane soldıer arı var
    public int concurrentWorkerBee = 0; //base node kac tane worker var

    public string concurrentSoldierBeeText;
    public string concurrentWorkerBeeText;

    enum Player
    {
        P1,
        P2,
    }

    private void Awake()
    {
        //_bee = GetComponent<Bee>();
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
        var tempTransformOfChildren = gameObject.GetComponentsInChildren<Transform>();
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
        //update iste falan fistik
    }

    public void CreateSoldierBee()
    {
        
        if (baseOwner == Player.P1)
        {
            
            if (currentBaseResource >= _soldierBeeResourceCost && playerManager.concurrentBee_P1 < _maxBeeQuota)
            {
                currentBaseResource = currentBaseResource - _soldierBeeResourceCost; //decrease resource cost from total
                playerManager.concurrentBee_P1 = playerManager.concurrentBee_P1 + 1; //update p1 concurrent bee
                concurrentSoldierBee++;
                concurrentSoldierBeeText = "Soldier: " + concurrentSoldierBee;
                GUIManager.Instance.baseNodeConcurrentBeePanel_P1.GetComponentInChildren<Text>().text = concurrentSoldierBeeText.ToString();
                //spawn pos fixed listenin ilk elemani degil de duzgun bir mantik ile hangi noktada spawn edecegine karar vermeli(arilar ust uste binmesin, yazik gunah)
                //GameObject tempObj = Instantiate(soldierBeePrefab,spawnPositions[0].position,Quaternion.identity); //instantiate a bee from base player 1

                //tempObj.transform.parent = playerManager.beePool_P1.transform; //transport this bee into pool (cumburlop, gluk gluk gluk...)
                // spawnPositions[0].position += new Vector3(0,0.2f,0)  ; // Arılar gönderildikten sonra sorun yaratacak.

                //float randomX = Random.Range(transform.position.x -0.5f, transform.position.x + 0.5f );
                //float randomY = Random.Range(transform.position.y + 0.2f, transform.position.y + 1);
                //spawnPositions[0].position = new Vector3(randomX,randomY,0)  ; 
                //Debug.Log("ggg");
                
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
                // spawnPositions[0].position += new Vector3(0,0.2f,0)  ; // Arılar gönderildikten sonra sorun yaratacak.

                float randomX = Random.Range(transform.position.x -0.5f, transform.position.x + 0.5f );
                float randomY = Random.Range(transform.position.y + 0.2f, transform.position.y + 1);
                spawnPositions[0].position = new Vector3(randomX,randomY,0)  ; 
            }
            else
            {
                Debug.Log("CantCreateSoldier P2-> " + "CurrRes=" + currentBaseResource + ">" + "soldierCost= " + _soldierBeeResourceCost + " && " + "P1concurrBee= " + playerManager.concurrentBee_P1 + "<" + "MaxBeeQuota= " + _maxBeeQuota);
            }
        }
        else
        {
            Debug.LogWarning("Player settings may wrong. Check P1 and P2 settings or mailto: ardazeytin@outlook.com or Call 911");
        }

    }

    public void CreateWorkerBee()
    {
       if (baseOwner == Player.P1)
        {
           
            
            if (currentBaseResource >= _workerBeeResourceCost && playerManager.concurrentBee_P1 < _maxBeeQuota)
            {
                currentBaseResource = currentBaseResource - _workerBeeResourceCost; //decrease resource cost from total
                playerManager.concurrentBee_P1 = playerManager.concurrentBee_P1 + 1; //update p1 concurrent bee

                //spawn pos fixed listenin ilk elemani degil de duzgun bir mantik ile hangi noktada spawn edecegine karar vermeli(arilar ust uste binmesin, yazik gunah)
                GameObject tempObj = Instantiate(workerBeePrefab,spawnPositions[1].position,Quaternion.identity); //instantiate a bee from base player 1

                tempObj.transform.parent = playerManager.beePool_P1.transform; //transport this bee into pool (cumburlop, gluk gluk gluk...)
               // spawnPositions[0].position += new Vector3(0,0.2f,0)  ; // Arılar gönderildikten sonra sorun yaratacak.

                float randomX = Random.Range(transform.position.x -0.5f, transform.position.x + 0.5f );
                float randomY = Random.Range(transform.position.y - 0.2f, transform.position.y - 1);
                spawnPositions[1].position = new Vector3(randomX,randomY,0)  ; 
                
                
            }
            else
            {
                Debug.Log("CantCreateWorker P1-> " + "CurrRes=" + currentBaseResource + ">" + "WorkerCost= " + _workerBeeResourceCost + "&&" + " " + "P1concurrBee= " + playerManager.concurrentBee_P1 + "<" + "MaxBeeQuota= " + _maxBeeQuota);
            }
        }
        else if (baseOwner == Player.P2)
        {
            if (currentBaseResource >= _workerBeeResourceCost && playerManager.concurrentBee_P2 < _maxBeeQuota)
            {
                currentBaseResource = currentBaseResource - _workerBeeResourceCost; //decrease resource cost from total
                playerManager.concurrentBee_P2 = playerManager.concurrentBee_P2 + 1; //update p1 concurrent bee

                GameObject tempObj = Instantiate(workerBeePrefab, spawnPositions[1].position, Quaternion.identity); //instantiate a bee from base player 1
                tempObj.transform.parent = playerManager.beePool_P2.transform; //transport this bee into pool (cumburlop, gluk gluk gluk...)
                //Debug.Log("WALLLLLDOOOOOOOO!!");
                // spawnPositions[0].position += new Vector3(0,0.2f,0)  ; // Arılar gönderildikten sonra sorun yaratacak.

                float randomX = Random.Range(transform.position.x -0.5f, transform.position.x + 0.5f );
                float randomY = Random.Range(transform.position.y + 0.2f, transform.position.y + 1);
                spawnPositions[1].position = new Vector3(randomX,randomY,0)  ; 
            }
            else
            {
                Debug.Log("CantCreateWorker P2-> " + "CurrRes=" + currentBaseResource + ">" + "workerCost= " + _workerBeeResourceCost + " && " + "P2concurrBee= " + playerManager.concurrentBee_P2 + "<" + "MaxBeeQuota= " + _maxBeeQuota);
            }
        }
        else
        {
            Debug.LogWarning("Player settings may wrong. Check P1 and P2 settings or mailto: ardazeytin@outlook.com or Call 911");
        }
    }


    //standart resource gathering without using resource additional nodes
    private void AddHoneyStock()
    {
        Debug.Log("Base " + baseOwner +" resource= "+ currentBaseResource);
        currentBaseResource += 5;
    }


    //node highligth
    private void OnMouseDown()
    {
        _uiManager.Highlight(gameObject);
    }


}
