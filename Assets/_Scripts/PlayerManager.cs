using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //[HideInInspector]
    public GameObject base_P1;
    //[HideInInspector]
    public GameObject base_P2;
    
    //How many resources players have
    public int resource_P1 = 0;
    public int resource_P2 = 0;

    //How many bees players have
    public int concurrentBee_P1 = 0;
    public int concurrentBee_P2 = 0;

    private void Awake()
    {
        //init player1 & player2 base game object
        base_P1 = GameObject.FindGameObjectWithTag("BaseP1");
        base_P2 = GameObject.FindGameObjectWithTag("BaseP2");
    }

    private void Start()
    {

    }

    private void Update()
    {
        UpdatePlayerResourceValues();
    }

    //get player resource values
    void UpdatePlayerResourceValues()
    {
        resource_P1 = base_P1.GetComponent<BaseNode>().currentBaseResource;
        resource_P2 = base_P2.GetComponent<BaseNode>().currentBaseResource;
    }

}
