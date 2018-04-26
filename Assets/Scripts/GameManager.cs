using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager : NetworkBehaviour
{

    #region Singleton GameManager

    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject gm = new GameObject("GameManager");
                gm.AddComponent<GameManager>();
            }

            return _instance;
        }
    }

    private void Awake()
    {
        //singleton
        _instance = this; 

        //find player base nodes
        base_P1 = GameObject.FindGameObjectWithTag("BaseP1");
        base_P2 = GameObject.FindGameObjectWithTag("BaseP2");
    }

    #endregion

    [Header ("Game Rules")]
    //Game rule values
    public int soldierBeeResourceCost; //asker basarken kac kaynak harcansin
    public int workerBeeResourceCost; //isci basarken kac kaynak harcansin
    public int soldierBeeQuotaCost; //asker kac yer kaplasin
    public int workerBeeQuotaCost; //isci kac yer kaplasin
    public int maxBeeQuota; //oyuncularin maksimum ari kotasi

    //Base node kac Bee ile baslayacak?
    public int soldierBeeStartValue;
    public int workerBeeStartValue;

    [Header("Player Values")]

    [SyncVar]
    public int resource_P1 = 0; //How many resources player have?
    [SyncVar]
    public int resource_P2 = 0;
    [SyncVar]
    public int concurrentBee_P1 = 0;    //How many bees player have?
    [SyncVar]
    public int concurrentBee_P2 = 0;

    [Header("Base Nodes")]

    public GameObject base_P1;
    public GameObject base_P2;

    [Header("Network")]

    public int playerCount = 0;
    public List<GameObject> playerList;

    private void Start()
    {
        InvokeRepeating("AddResources", 1, 1);
    }

    //standart resource gathering without using resource additional nodes
    private void AddResources()
    {
        resource_P1 = resource_P1 + 5;
        resource_P2 = resource_P2 + 5;
    }
}
