﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Eksik Ozellikler->
//-->>kontrol noktalarinda orumcek mi kus mu ne sakat bir sey varmis
//-->>isci ari resource node'a, soldier ari ise sadece controlNodelara gidebilirmis
//-->>oyunucun ari buradaysa (worker yani) kaynak uretim baz miktari arttir.(buff gibi) (aslinda isciler base'e git gel yaptikca daha mantikli olur,  varsa gonullu yapsin)


public class Node : MonoBehaviour
{
    public int concurentBee = 0; //how many bees in this node?
    public int concurrentBee_P1 = 0;
    public int concurrentBee_P2 = 0;
    NodeType nodeType; // enum type of node

    public string nodeOwner = "P0"; //P0 = npc, P1 = player 1, P2 = player 2
    //public Color nodeSpriteColorOverlay; //p1 baskin ise mavi, p2 baskin ise kirmizi yap

    public Text concurrentBeeText; //show number of concurrentBee --Note: you have to put Text object every node manually in editor

    public NodeType NodeType1
    {
        get
        {
            return nodeType;
        }

        set
        {
            nodeType = value;
        }
    }

    public enum NodeType
    {
        Resource,
        Control,
    }

    private void Awake()
    {
        if (gameObject.CompareTag("ResourceNode"))
        {
            NodeType1 = NodeType.Resource;
        }
        else if (gameObject.CompareTag("ControlNode"))
        {
            NodeType1 = NodeType.Control;
        }
    }

    private void Update()
    {
        CalculateConcurrentBee();
        DecideNodeOwner();
        UpdateConcurrentBeeText();
    }

    void CalculateConcurrentBee()
    {
        if (concurrentBee_P1 > concurrentBee_P2)
        {
            concurentBee = concurrentBee_P1 - concurrentBee_P2;
            concurrentBeeText.color = Color.cyan;
        }
        else if (concurrentBee_P2 > concurrentBee_P1)
        {
            concurentBee = concurrentBee_P2 - concurrentBee_P1;
            concurrentBeeText.color = Color.red;
        }
        else if (concurrentBee_P1 == 0 && concurrentBee_P2 == 0)
        {
            concurentBee = 0;
            concurrentBeeText.color = Color.black;
        }

    }

    void DecideNodeOwner()
    {
        if (concurrentBee_P1 > concurrentBee_P2)
        {
            nodeOwner = "P1";
            //do other stuff
        }
        else if (concurrentBee_P2 > concurrentBee_P1)
        {
            nodeOwner = "P2";
            // do other stuff
        }
        else if (concurrentBee_P1 == concurrentBee_P2)
        {
            nodeOwner = "P0";
        }
    }

    //# of bee above node 
    void UpdateConcurrentBeeText()
    {
        if (concurrentBeeText != null)
        {
            if (nodeOwner == "P1")
            {
                concurrentBeeText.text = concurrentBee_P1.ToString();
            }
            else if (nodeOwner == "P2")
            {
                concurrentBeeText.text = concurrentBee_P2.ToString();
            }
            else
            {
                concurrentBeeText.text = concurentBee.ToString();
            }
        }
    }
}
