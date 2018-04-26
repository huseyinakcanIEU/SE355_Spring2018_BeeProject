﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class BaseNode : NetworkBehaviour
{
    public int healthOfBase; //kralice ari vs icin kullanilabilir(suan kullanilmiyor)
    
    //Arda: usttekki prop.ler eski alttakiler yeni 06:43AM

    Player baseOwner; //enum P1 P2

    //bee prefabs
    public GameObject soldierBeePrefab;
    public GameObject workerBeePrefab;

    //costs and quotas(do not edit these values, use GameManager)
    private int _soldierBeeResourceCost;
    private int _workerBeeResourceCost;
    private int _soldierBeeQuotaCost;
    private int _workerBeeQuotaCost;
    private int _maxBeeQuota;
    private int _soldierBeeStartValue;
    private int _workerBeeStartValue;

    private List<Transform> spawnPositions = new List<Transform>(); //bee spawn positions (you cant create empty transform! use vector3)

    [SyncVar]
    public int concurrentSoldierBee; //base de kac tane soldıer arı var
    [SyncVar]
    public int concurrentWorkerBee; //base node kac tane worker var
    [SyncVar]
    public int concurrentBee ; //toplamda kac tane ari base uzerinde bekliyor

    [SyncVar]
    private string concurrentSoldierBeeText;
    [SyncVar]
    private string concurrentWorkerBeeText;
    [SyncVar]
    private string resourceText;

    //encapsulation baseowner
    public Player BaseOwner
    {
        get
        {
            return baseOwner;
        }

        set
        {
            baseOwner = value;
        }
    }

    public enum Player
    {
        P1,
        P2,
    }

    private void Awake()
    {
        //set base owner
        if (GameManager.Instance.base_P1 == this.gameObject)
        {
            baseOwner = Player.P1;
        }
        else if (GameManager.Instance.base_P2 == this.gameObject)
        {
            baseOwner = Player.P2;
        }

        //set Costs & start values
        _soldierBeeResourceCost = GameManager.Instance.soldierBeeResourceCost;
        _workerBeeResourceCost = GameManager.Instance.workerBeeResourceCost;
        _soldierBeeQuotaCost = GameManager.Instance.soldierBeeQuotaCost;
        _workerBeeQuotaCost = GameManager.Instance.workerBeeQuotaCost;
        _soldierBeeStartValue = GameManager.Instance.soldierBeeStartValue;
        _workerBeeStartValue = GameManager.Instance.workerBeeStartValue;

        //set max bee quota
        _maxBeeQuota = GameManager.Instance.maxBeeQuota;
        
        //set start bee numbers
        concurrentSoldierBee = _soldierBeeStartValue;
        concurrentWorkerBee = _workerBeeStartValue;

    }

    void Update()
    {
        RpcUpdateConcurrentBeePanel();
    }


    [ClientRpc]
    private void RpcUpdateConcurrentBeePanel()
    {
        concurrentBee = concurrentSoldierBee + concurrentWorkerBee;
        concurrentSoldierBeeText = "Soldier: " + concurrentSoldierBee;
        concurrentWorkerBeeText = "Worker: " + concurrentWorkerBee;
        

        //update base concurrentBee panel(base uzerindeki Soldier:0 Worker:0 yazan panel) ( Resource u da güncelliyoruz.) 
        if (baseOwner == Player.P1)
        {
            resourceText = "Resource: " + GameManager.Instance.resource_P1;
            GUIManager.Instance.baseNodeConcurrentBeePanel_P1.transform.GetChild(0).GetComponentInChildren<Text>().text = concurrentSoldierBeeText.ToString();
            GUIManager.Instance.baseNodeConcurrentBeePanel_P1.transform.GetChild(1).GetComponentInChildren<Text>().text = concurrentWorkerBeeText.ToString();
            GUIManager.Instance.baseNodeResourcePanel_P1.transform.GetChild(0).GetComponentInChildren<Text>().text = resourceText;

        }
        else if (baseOwner == Player.P2)
        {
            resourceText = "Resource: " + GameManager.Instance.resource_P2;
            GUIManager.Instance.baseNodeConcurrentBeePanel_P2.transform.GetChild(0).GetComponentInChildren<Text>().text = concurrentSoldierBeeText.ToString();
            GUIManager.Instance.baseNodeConcurrentBeePanel_P2.transform.GetChild(1).GetComponentInChildren<Text>().text = concurrentWorkerBeeText.ToString();
            GUIManager.Instance.baseNodeResourcePanel_P2.transform.GetChild(0).GetComponentInChildren<Text>().text = resourceText;
        }
    }


    [Command]
    public void CmdCreateSoldierBee()
    {
        //Base'in sahibi player 1 ise
        if (baseOwner == Player.P1)
        {
            //Yeterli kaynak ve kota varsa asker uret
            if (GameManager.Instance.resource_P1 >= _soldierBeeResourceCost && GameManager.Instance.concurrentBee_P1 < _maxBeeQuota)
            {
                GameManager.Instance.resource_P1 = GameManager.Instance.resource_P1 - _soldierBeeResourceCost; //decrease resource cost from total
                GameManager.Instance.concurrentBee_P1 = GameManager.Instance.concurrentBee_P1 + 1; //update p1 concurrent bee
                concurrentSoldierBee++; //increase concurrent soldier of P1 BaseNode
                concurrentSoldierBeeText = "Soldier: " + concurrentSoldierBee; //update P1 base panel string
                GUIManager.Instance.baseNodeConcurrentBeePanel_P1.transform.GetChild(0).GetComponentInChildren<Text>().text = concurrentSoldierBeeText.ToString(); //update panel text
            }
            else
            {
                Debug.Log("CantCreateSoldier P1-> " + "CurrRes=" + GameManager.Instance.resource_P1 + ">" + "soldierCost= " + _soldierBeeResourceCost + "&&" + " " + "P1concurrBee= " + GameManager.Instance.concurrentBee_P1 + "<" + "MaxBeeQuota= " + _maxBeeQuota);
            }
        }
        else if (baseOwner == Player.P2)
        {
            if (GameManager.Instance.resource_P2 >= _soldierBeeResourceCost && GameManager.Instance.concurrentBee_P2 < _maxBeeQuota)
            {
                GameManager.Instance.resource_P2 = GameManager.Instance.resource_P2 - _soldierBeeResourceCost; //decrease resource cost from total
                GameManager.Instance.concurrentBee_P2 = GameManager.Instance.concurrentBee_P2 + 1; //update p1 concurrent bee
                concurrentSoldierBee++;
                concurrentSoldierBeeText = "Soldier: " + concurrentSoldierBee;
                GUIManager.Instance.baseNodeConcurrentBeePanel_P2.transform.GetChild(0).GetComponentInChildren<Text>().text = concurrentSoldierBeeText.ToString();
            }
            else
            {
                Debug.Log("CantCreateSoldier P2-> " + "CurrRes=" + GameManager.Instance.resource_P2 + ">" + "soldierCost= " + _soldierBeeResourceCost + " && " + "P1concurrBee= " + GameManager.Instance.concurrentBee_P1 + "<" + "MaxBeeQuota= " + _maxBeeQuota);
            }
        }
        else
        {
            Debug.LogWarning("Player settings may wrong. Check P1 and P2 settings or mailto: ardazeytin@outlook.com or Call 911");
        }

    }

    [Command]
    public void CmdCreateWorkerBee()
    {
       if (baseOwner == Player.P1)
        {
            if (GameManager.Instance.resource_P1 >= _workerBeeResourceCost && GameManager.Instance.concurrentBee_P1 < _maxBeeQuota)
            {
                GameManager.Instance.resource_P1 = GameManager.Instance.resource_P1 - _workerBeeResourceCost; //decrease resource cost from total
                GameManager.Instance.concurrentBee_P1 = GameManager.Instance.concurrentBee_P1 + 1; //update p1 concurrent bee
                concurrentWorkerBee++;
                concurrentWorkerBeeText = "Worker: " + concurrentWorkerBee;
                GUIManager.Instance.baseNodeConcurrentBeePanel_P1.transform.GetChild(1).GetComponentInChildren<Text>().text = concurrentWorkerBeeText.ToString();
            }
            else
            {
                Debug.Log("CantCreateWorker P1-> " + "CurrRes=" + GameManager.Instance.resource_P1 + ">" + "WorkerCost= " + _workerBeeResourceCost + "&&" + " " + "P1concurrBee= " + GameManager.Instance.concurrentBee_P1 + "<" + "MaxBeeQuota= " + _maxBeeQuota);
            }
        }
        else if (baseOwner == Player.P2)
        {
            if (GameManager.Instance.resource_P2 >= _workerBeeResourceCost && GameManager.Instance.concurrentBee_P2 < _maxBeeQuota)
            {
                GameManager.Instance.resource_P2 = GameManager.Instance.resource_P2 - _workerBeeResourceCost; //decrease resource cost from total
                GameManager.Instance.concurrentBee_P2 = GameManager.Instance.concurrentBee_P2 + 1; //update p1 concurrent bee
                concurrentWorkerBee++;
                concurrentWorkerBeeText = "Worker: " + concurrentWorkerBee;
                GUIManager.Instance.baseNodeConcurrentBeePanel_P2.transform.GetChild(1).GetComponentInChildren<Text>().text = concurrentWorkerBeeText.ToString();
            }
            else
            {
                Debug.Log("CantCreateWorker P2-> " + "CurrRes=" + GameManager.Instance.resource_P2 + ">" + "workerCost= " + _workerBeeResourceCost + " && " + "P2concurrBee= " + GameManager.Instance.concurrentBee_P2 + "<" + "MaxBeeQuota= " + _maxBeeQuota);
            }
        }
        else
        {
            Debug.LogWarning("Player settings may wrong. Check P1 and P2 settings or mailto: ardazeytin@outlook.com or Call 911");
        }
    }

}
