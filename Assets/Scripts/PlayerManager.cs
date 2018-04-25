using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerManager : NetworkBehaviour
{
    //[HideInInspector]
    public GameObject base_P1;
    //[HideInInspector]
    public GameObject base_P2;
    
    //How many resources players have
    

    //Parent gameobject to hold instatiated bees (can be useable for search quary)
    //public GameObject beePool_P1;
    //public GameObject beePool_P2;

    private void Awake()
    {
        //init base game object of players
        base_P1 = GameObject.FindGameObjectWithTag("BaseP1");
        base_P2 = GameObject.FindGameObjectWithTag("BaseP2");

        //init bee pools
        //beePool_P1 = GameObject.FindGameObjectWithTag("BeePoolPlayer1");
        //beePool_P2 = GameObject.FindGameObjectWithTag("BeePoolPlayer2");
    }

    private void Update()
    {
        UpdatePlayerResourceValues();
    }

    //get player resource values
    void UpdatePlayerResourceValues()
    {
        //resource_P1 = base_P1.GetComponent<BaseNode>().currentBaseResource;
        //resource_P2 = base_P2.GetComponent<BaseNode>().currentBaseResource;
    }

}
