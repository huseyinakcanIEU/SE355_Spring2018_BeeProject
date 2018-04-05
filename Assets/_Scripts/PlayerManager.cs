using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [HideInInspector]
    public GameObject base_P1;
    [HideInInspector]
    public GameObject base_P2;

    public int resource_P1;
    public int resource_P2;

    private void Awake()
    {
        //init player1 & player2 base game object
        base_P1 = GameObject.FindGameObjectWithTag("BaseP1");
        base_P2 = GameObject.FindGameObjectWithTag("BaseP2");
    }

    private void Update()
    {
        UpdatePlayerResourceValues();
    }

    //get player resource values
    void UpdatePlayerResourceValues()
    {
        resource_P1 = base_P1.GetComponent<BaseNode>().playerResource;
        resource_P2 = base_P2.GetComponent<BaseNode>().playerResource;
    }

}
