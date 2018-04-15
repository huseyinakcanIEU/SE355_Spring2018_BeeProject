using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

//Eksik Ozellikler->
//-->>kontrol noktalarinda orumcek mi kus mu ne sakat bir sey varmis
//-->>oyunucun ari buradaysa (worker yani) kaynak uretim baz miktari arttir.(buff gibi) (aslinda isciler base'e git gel yaptikca daha mantikli olur,  varsa gonullu yapsin)


public class Node : NetworkBehaviour
{
    [SyncVar]
    public int concurentBee = 0; //how many bees in this node?
    [SyncVar]
    public int concurrentBee_P1 = 0; //how many bees Player1 have
    [SyncVar]
    public int concurrentBee_P2 = 0; // how many bees Player2 have
    [SyncVar]
    public int concurrentBee_P0 = 0; // how many bees Default enemy have
    NodeType nodeType; // enum type of node
    public int resourcePerBee; // Resource için her arı başına taşınacak resource

    private float nextTransferTime;
    public int transferInterval = 1; //Sending resource rate(each second)

    [SyncVar]
    public string nodeOwner = "P0"; //P0 = No owner(NPC or server), P1 = player 1, P2 = player 2

    //[SyncVar]
    public Text concurrentBeeText; //show number of concurrentBee --Note: you have to put Text object every node manually in editor
    

    //encapsulation
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
        //Decide node type before start the game
        if (gameObject.CompareTag("ResourceNode"))
        {
            NodeType1 = NodeType.Resource;
            //For every node its different so change it in inspector 
            //resourcePerBee = 5;

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
        GatherResourceWithWorker(); //Increase resouce gain by # of workers in this node
    }

    //Calculate concurrentBee of node and set text color to owner(P1 = blue/cyan P2 = red)
    void CalculateConcurrentBee()
    {
        
        if(nodeType == NodeType.Control){
        
            if (concurrentBee_P1 > concurrentBee_P2)
            {
                concurentBee = concurrentBee_P1 - concurrentBee_P2;
                concurrentBeeText.color = Color.cyan;
                //Debug.Log("Here");
                GetComponent<SpriteRenderer>().color = new Color(0,1f,1f,0.5f);
            }
            else if (concurrentBee_P2 > concurrentBee_P1)
            {
                concurentBee = concurrentBee_P2 - concurrentBee_P1;
                concurrentBeeText.color = Color.red;
                GetComponent<SpriteRenderer>().color = new Color(1f,0,0,0.5f);

            }
            else if (concurrentBee_P1 == 0 && concurrentBee_P2 == 0)
            {
                concurentBee = 0;
                concurrentBeeText.color = Color.black;
                GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0.5f);

            }
    
        }
        // Resource ise concurrent bee iki kullanıcının worker toplamı kadar
        else
        {
            concurentBee = concurrentBee_P1 + concurrentBee_P2;
        }
    }

    void DecideNodeOwner()
    {
        // Control noktasıysa node sahibini belirle.
        if(nodeType == NodeType.Control){
            
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
                nodeOwner = "P0"; //Non
            }
        }
    }

    //# of bee above node 
    void UpdateConcurrentBeeText()
    {
        if (concurrentBeeText != null)
        {
            // Control noktasıysa belirle.
            if(nodeType == NodeType.Control){
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
                    concurrentBeeText.text = concurentBee.ToString(); //Shows black 0 text
                }
            }
            //Resource ise solda P1in sağda P2nin worker sayılarını göster. 
            else
            {
               
                concurrentBeeText.text = concurrentBee_P1 + "  " + concurrentBee_P2;
                concurrentBeeText.color = Color.black;
            }
        }
    }

    // Increasing Base Resource according to number of worker bee in resource
    void GatherResourceWithWorker()
    {
        if (Time.time > nextTransferTime)
        {
            nextTransferTime = Time.time + transferInterval;

            if (nodeType == NodeType.Resource)
            {
                GameObject.Find("Base1").GetComponent<BaseNode>().currentBaseResource += resourcePerBee * concurrentBee_P1;
                GameObject.Find("Base2").GetComponent<BaseNode>().currentBaseResource += resourcePerBee * concurrentBee_P2;
            }
        }
    }   
}
