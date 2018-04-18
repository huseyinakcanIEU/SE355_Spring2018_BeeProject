using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    private GameObject bee;

    public bool isFirstClick = false;
    public int transferInterval = 1; //Sending bee rate(each second)
    private float nextTransferTime = 0; 

    public GameObject underMouseObject;
    public GameObject initialObject ; //first selected object
    public GameObject targetObject; //second selected object
    
    public GameObject underMouseObject2;
    public GameObject initialObject2; //first selected object
    public GameObject targetObject2; //second selected object
    
    
    int id = -1;

    void Update()
    {
        Swipe(); //click & drag & drop (mouse)
        underMouseObject = OnTargetOver();
        TransferBee();
        
    }

    private void TransferBee()
    {
        //ilk defa tiklandi ve ilk tiklanan uzerinde durulmuyorsa
        if (/*isFirstClick == true &&*/ underMouseObject != initialObject)
        {
            targetObject = underMouseObject; //gonderme hedefini al (ilk tiklanan obje initial, sonraki target)
            
            //Asagidaki kosullara gore ari gonder

            //Base'den node'a gondermeyi dene
            if (initialObject.GetComponent<BaseNode>() != null && targetObject != null && targetObject.GetComponent<Node>() != null && initialObject.GetComponent<BaseNode>().concurrentBee > 0)
            {
                //if target node control point
                if (targetObject.GetComponent<Node>().NodeType1 == Node.NodeType.Control)
                {
                    if (Time.time > nextTransferTime)
                    {
                        nextTransferTime = Time.time + transferInterval;
                        if (initialObject.GetComponent<BaseNode>().concurrentSoldierBee > 0)
                        {
                            if (initialObject.GetComponent<BaseNode>().BaseOwner == BaseNode.Player.P1)
                            {
                                if (targetObject != null)
                                {
                                    //P1 base is sending P1 or P0 node
                                    if (targetObject.GetComponent<Node>().nodeOwner == "P1" || targetObject.GetComponent<Node>().nodeOwner == "P0")
                                    {
                                        initialObject.GetComponent<BaseNode>().concurrentSoldierBee--;
                                        if (targetObject.GetComponent<Node>().concurrentBee_P2 > 0)
                                        {
                                            targetObject.GetComponent<Node>().concurrentBee_P2--;
                                        }
                                        else
                                        {
                                            targetObject.GetComponent<Node>().concurrentBee_P1++;
                                        }

                                        Debug.Log("Transferred Soldier Bee: " + initialObject.name + "-->" + targetObject.name);
                                    }
                                    //P1 base is sending P2 node
                                    else if (targetObject.GetComponent<Node>().nodeOwner == "P2")
                                    {
                                        initialObject.GetComponent<BaseNode>().concurrentSoldierBee--;
                                        
                                        if (targetObject.GetComponent<Node>().concurrentBee_P2 > 0)
                                        {
                                            targetObject.GetComponent<Node>().concurrentBee_P2--;
                                        }
                                        else
                                        {
                                            targetObject.GetComponent<Node>().concurrentBee_P1++;
                                        }

                                        Debug.Log("Transferred Soldier Bee: " + initialObject.name + "-->" + targetObject.name);
                                    }
                                } 
                            }
                            else if (initialObject.GetComponent<BaseNode>().BaseOwner == BaseNode.Player.P2)
                            {
                                if (targetObject != null)
                                {
                                    //P2 is sending P1
                                    if (targetObject.GetComponent<Node>().nodeOwner == "P1")
                                    {
                                        initialObject.GetComponent<BaseNode>().concurrentSoldierBee--;
                                        
                                        if (targetObject.GetComponent<Node>().concurrentBee_P1 > 0)
                                        {
                                            targetObject.GetComponent<Node>().concurrentBee_P1--;
                                        }
                                        else
                                        {
                                            targetObject.GetComponent<Node>().concurrentBee_P2++;
                                        }
                                    }
                                    //P2 is sending P2 or P0
                                    else if (targetObject.GetComponent<Node>().nodeOwner == "P2" || targetObject.GetComponent<Node>().nodeOwner == "P0")
                                    {
                                        initialObject.GetComponent<BaseNode>().concurrentSoldierBee--;
                                        
                                        if (targetObject.GetComponent<Node>().concurrentBee_P1 > 0)
                                        {
                                            targetObject.GetComponent<Node>().concurrentBee_P1--;
                                        }
                                        else
                                        {
                                            targetObject.GetComponent<Node>().concurrentBee_P2++;
                                        }
                                    }
                                }
                                
                            }
                        }
                        else
                        {
                            Debug.Log("Not enough soldier in ->> " + initialObject.name);
                        }
                    }

                }
                //if target node resource point
                else if (targetObject.GetComponent<Node>().NodeType1 == Node.NodeType.Resource)
                {
                    if (Time.time > nextTransferTime)
                    {
                        nextTransferTime = Time.time + transferInterval;
                        if (initialObject.GetComponent<BaseNode>().concurrentWorkerBee > 0)
                        {
                            if (initialObject.GetComponent<BaseNode>().BaseOwner == BaseNode.Player.P1)
                            {
                                if (targetObject != null)
                                {
                                    //P1 base is sending P1 or P0 node
                                    if (targetObject.GetComponent<Node>().nodeOwner == "P1" || targetObject.GetComponent<Node>().nodeOwner == "P0")
                                    {
                                        initialObject.GetComponent<BaseNode>().concurrentWorkerBee--;
                                        if (targetObject.GetComponent<Node>().concurrentBee_P2 > 0)
                                        {
                                            targetObject.GetComponent<Node>().concurrentBee_P2--;
                                        }
                                        else
                                        {
                                            targetObject.GetComponent<Node>().concurrentBee_P1++;
                                        }

                                        Debug.Log("Transferred Worker Bee: " + initialObject.name + "-->" + targetObject.name);
                                    }
                                    //P1 base is sending P2 node
                                    else if (targetObject.GetComponent<Node>().nodeOwner == "P2")
                                    {
                                        initialObject.GetComponent<BaseNode>().concurrentWorkerBee--;

                                        if (targetObject.GetComponent<Node>().concurrentBee_P2 > 0)
                                        {
                                            targetObject.GetComponent<Node>().concurrentBee_P2--;
                                        }
                                        else
                                        {
                                            targetObject.GetComponent<Node>().concurrentBee_P1++;
                                        }

                                        Debug.Log("Transferred Worker Bee: " + initialObject.name + "-->" + targetObject.name);
                                    }
                                }
                            }
                            else if (initialObject.GetComponent<BaseNode>().BaseOwner == BaseNode.Player.P2)
                            {
                                if (targetObject != null)
                                {
                                    //P2 is sending P1
                                    if (targetObject.GetComponent<Node>().nodeOwner == "P1")
                                    {
                                        initialObject.GetComponent<BaseNode>().concurrentWorkerBee--;

                                        if (targetObject.GetComponent<Node>().concurrentBee_P1 > 0)
                                        {
                                            targetObject.GetComponent<Node>().concurrentBee_P1--;
                                        }
                                        else
                                        {
                                            targetObject.GetComponent<Node>().concurrentBee_P2++;
                                        }

                                        Debug.Log("Transferred Worker Bee " + initialObject.name + "-->" + targetObject.name);
                                    }
                                    //P2 is sending P2 or P0
                                    else if (targetObject.GetComponent<Node>().nodeOwner == "P2" || targetObject.GetComponent<Node>().nodeOwner == "P0")
                                    {
                                        initialObject.GetComponent<BaseNode>().concurrentWorkerBee--;

                                        if (targetObject.GetComponent<Node>().concurrentBee_P1 > 0)
                                        {
                                            targetObject.GetComponent<Node>().concurrentBee_P1--;
                                        }
                                        else
                                        {
                                            targetObject.GetComponent<Node>().concurrentBee_P2++;
                                        }

                                        Debug.Log("Transferred Worker Bee " + initialObject.name + "-->" + targetObject.name);
                                    }
                                }
                            }
                        }
                        else
                        {
                            Debug.Log("Not enough worker in ->> " + initialObject.name);
                        }
                    }
                }
            }
            //Node'dan node'a gonderme
            else if (initialObject.GetComponent<Node>() != null && targetObject != null && targetObject.GetComponent<Node>() != null && initialObject.GetComponent<Node>().concurentBee > 0)
            {
                //Debug.Log("NODE TO NODE");
                if (Time.time > nextTransferTime)
                {
                    nextTransferTime = Time.time + transferInterval;
                    //resource to resource point | control to control point check. Example: Dont send soldier to resource point
                    if (initialObject.GetComponent<Node>().NodeType1 == targetObject.GetComponent<Node>().NodeType1)
                    {
                        if (initialObject.GetComponent<Node>().concurentBee > 0)
                        {
                            //P1 is sender
                            if (initialObject.GetComponent<Node>().nodeOwner == "P1" && initialObject.GetComponent<Node>().concurrentBee_P1 > 0)
                            {
                                //P1 is sending to P1 or  P0
                                if (targetObject != null)
                                {
                                    if (targetObject.GetComponent<Node>().nodeOwner == "P1" || targetObject.GetComponent<Node>().nodeOwner == "P0" || targetObject.GetComponent<Node>().nodeOwner == "P2")
                                    {
                                        initialObject.GetComponent<Node>().concurrentBee_P1--;

                                        if (targetObject.GetComponent<Node>().concurrentBee_P2 > 0)
                                        {
                                            targetObject.GetComponent<Node>().concurrentBee_P2--;
                                        }
                                        else
                                        {
                                            targetObject.GetComponent<Node>().concurrentBee_P1++;
                                        }

                                        Debug.Log("Transferred Bee :" + initialObject.name + "-->" + targetObject.name);
                                    }
                                }
                            }
                            //P2 is sender
                            else if (initialObject.GetComponent<Node>().nodeOwner == "P2" && initialObject.GetComponent<Node>().concurrentBee_P2 > 0)
                            {
                                //P2 is sending
                                if (targetObject != null)
                                {
                                    if (targetObject.GetComponent<Node>().nodeOwner == "P1" || targetObject.GetComponent<Node>().nodeOwner == "P0" || targetObject.GetComponent<Node>().nodeOwner == "P2")
                                    {
                                        initialObject.GetComponent<Node>().concurrentBee_P2--;
                                       
                                        if (targetObject.GetComponent<Node>().concurrentBee_P1 > 0)
                                        {
                                            targetObject.GetComponent<Node>().concurrentBee_P1--;
                                        }
                                        else
                                        {
                                            targetObject.GetComponent<Node>().concurrentBee_P2++;
                                        }

                                        Debug.Log("Transferred Bee :" + initialObject.name + "-->" + targetObject.name);
                                    }  
                                }
                            }
                        }
                        else
                        {
                            Debug.Log("Not enough Bee in ->> " + initialObject.name);
                        }
                    }
                    else
                    {
                        Debug.Log("Node type didnt match! " + initialObject.name + " != " + targetObject.name);
                    }
                }
            }
            //Node'dan base'e gonderme
            else if (initialObject.GetComponent<Node>() != null && targetObject != null && targetObject.GetComponent<BaseNode>() != null && initialObject.GetComponent<Node>().concurentBee > 0)
            {
                //Debug.Log("NODE TO BASEEE");
                //if sender node is control point
                if (initialObject.GetComponent<Node>().NodeType1 == Node.NodeType.Control)
                {
                    if (Time.time > nextTransferTime)
                    {
                        nextTransferTime = Time.time + transferInterval;
                        if (initialObject.GetComponent<Node>().concurentBee > 0)
                        {
                            //P1 sending bee to a base
                            if (initialObject.GetComponent<Node>().nodeOwner == "P1" && initialObject.GetComponent<Node>().concurrentBee_P1 > 0)
                            {
                                initialObject.GetComponent<Node>().concurrentBee_P1--;
                                //P1 fallback to own base
                                if (targetObject.GetComponent<BaseNode>().BaseOwner == BaseNode.Player.P1)
                                {
                                    targetObject.GetComponent<BaseNode>().concurrentSoldierBee++;
                                }
                                //P1 Attack to P2 base
                                else if (targetObject.GetComponent<BaseNode>().BaseOwner == BaseNode.Player.P2)
                                {
                                    targetObject.GetComponent<BaseNode>().concurrentSoldierBee--;
                                }

                                Debug.Log("Transferred Soldier Bee: " + initialObject.name + "-->" + targetObject.name);
                            }
                            //P2 sending bee to a base
                            else if (initialObject.GetComponent<Node>().nodeOwner == "P2" && initialObject.GetComponent<Node>().concurrentBee_P2 > 0)
                            {
                                initialObject.GetComponent<Node>().concurrentBee_P2--;
                                //P2 attack to P1 base
                                if (targetObject.GetComponent<BaseNode>().BaseOwner == BaseNode.Player.P1)
                                {
                                    targetObject.GetComponent<BaseNode>().concurrentSoldierBee--;
                                }
                                //P2 fallback to own base
                                else if (targetObject.GetComponent<BaseNode>().BaseOwner == BaseNode.Player.P2)
                                {
                                    targetObject.GetComponent<BaseNode>().concurrentSoldierBee++;
                                }

                                Debug.Log("Transferred Soldier Bee: " + initialObject.name + "-->" + targetObject.name);
                            }
                        }
                        else
                        {
                            Debug.Log("Not enough soldier in ->> " + initialObject.name);
                        }
                    }

                }
                //if sender node is resource point
                else if (initialObject.GetComponent<Node>().NodeType1 == Node.NodeType.Resource)
                {
                    if (Time.time > nextTransferTime)
                    {
                        nextTransferTime = Time.time + transferInterval;
                        if (initialObject.GetComponent<Node>().concurentBee > 0)
                        {
                            //P1 sending bee to a base
                            if (initialObject.GetComponent<Node>().nodeOwner == "P1" && initialObject.GetComponent<Node>().concurrentBee_P1 > 0)
                            {
                                initialObject.GetComponent<Node>().concurrentBee_P1--;
                                //P1 fallback to own base
                                if (targetObject.GetComponent<BaseNode>().BaseOwner == BaseNode.Player.P1)
                                {
                                    targetObject.GetComponent<BaseNode>().concurrentWorkerBee++;
                                }
                                //P1 Attack to P2 base
                                else if (targetObject.GetComponent<BaseNode>().BaseOwner == BaseNode.Player.P2)
                                {
                                    targetObject.GetComponent<BaseNode>().concurrentWorkerBee--;
                                }

                                Debug.Log("Transferred Soldier Bee: " + initialObject.name + "-->" + targetObject.name);
                            }
                            //P2 sending bee to a base
                            else if (initialObject.GetComponent<Node>().nodeOwner == "P2" && initialObject.GetComponent<Node>().concurrentBee_P2 > 0)
                            {
                                initialObject.GetComponent<Node>().concurrentBee_P2--;
                                //P2 attack to P1 base
                                if (targetObject.GetComponent<BaseNode>().BaseOwner == BaseNode.Player.P1)
                                {
                                    targetObject.GetComponent<BaseNode>().concurrentWorkerBee--;
                                }
                                //P2 fallback to own base
                                else if (targetObject.GetComponent<BaseNode>().BaseOwner == BaseNode.Player.P2)
                                {
                                    targetObject.GetComponent<BaseNode>().concurrentWorkerBee++;
                                }

                                Debug.Log("Transferred Soldier Bee: " + initialObject.name + "-->" + targetObject.name);
                            }
                        }
                        else
                        {
                            Debug.Log("Not enough worker in ->> " + initialObject.name);
                        }
                    }
                }
            }
        }
        // Debug.Log("There is a " + underMouseObject + " under your cursor");
    }
    
    
    
    private void TransferBeeSecond()
    {
        //ilk defa tiklandi ve ilk tiklanan uzerinde durulmuyorsa
        if (/*isFirstClick == true &&*/ underMouseObject2 != initialObject2)
        {
            targetObject2 = underMouseObject2; //gonderme hedefini al (ilk tiklanan obje initial, sonraki target)
            
            //Asagidaki kosullara gore ari gonder

            //Base'den node'a gondermeyi dene
            if (initialObject2.GetComponent<BaseNode>() != null && targetObject2 != null && targetObject2.GetComponent<Node>() != null && initialObject2.GetComponent<BaseNode>().concurrentBee > 0)
            {
                //if target node control point
                if (targetObject2.GetComponent<Node>().NodeType1 == Node.NodeType.Control)
                {
                    if (Time.time > nextTransferTime)
                    {
                        nextTransferTime = Time.time + transferInterval;
                        if (initialObject2.GetComponent<BaseNode>().concurrentSoldierBee > 0)
                        {
                            if (initialObject2.GetComponent<BaseNode>().BaseOwner == BaseNode.Player.P1)
                            {
                                if (targetObject2 != null)
                                {
                                    //P1 base is sending P1 or P0 node
                                    if (targetObject2.GetComponent<Node>().nodeOwner == "P1" || targetObject2.GetComponent<Node>().nodeOwner == "P0")
                                    {
                                        initialObject2.GetComponent<BaseNode>().concurrentSoldierBee--;
                                        if (targetObject2.GetComponent<Node>().concurrentBee_P2 > 0)
                                        {
                                            targetObject2.GetComponent<Node>().concurrentBee_P2--;
                                        }
                                        else
                                        {
                                            targetObject2.GetComponent<Node>().concurrentBee_P1++;
                                        }

                                        Debug.Log("Transferred Soldier Bee: " + initialObject2.name + "-->" + targetObject2.name);
                                    }
                                    //P1 base is sending P2 node
                                    else if (targetObject2.GetComponent<Node>().nodeOwner == "P2")
                                    {
                                        initialObject2.GetComponent<BaseNode>().concurrentSoldierBee--;
                                        
                                        if (targetObject2.GetComponent<Node>().concurrentBee_P2 > 0)
                                        {
                                            targetObject2.GetComponent<Node>().concurrentBee_P2--;
                                        }
                                        else
                                        {
                                            targetObject2.GetComponent<Node>().concurrentBee_P1++;
                                        }

                                        Debug.Log("Transferred Soldier Bee: " + initialObject2.name + "-->" + targetObject.name);
                                    }
                                } 
                            }
                            else if (initialObject2.GetComponent<BaseNode>().BaseOwner == BaseNode.Player.P2)
                            {
                                if (targetObject2 != null)
                                {
                                    //P2 is sending P1
                                    if (targetObject2.GetComponent<Node>().nodeOwner == "P1")
                                    {
                                        initialObject2.GetComponent<BaseNode>().concurrentSoldierBee--;
                                        
                                        if (targetObject2.GetComponent<Node>().concurrentBee_P1 > 0)
                                        {
                                            targetObject2.GetComponent<Node>().concurrentBee_P1--;
                                        }
                                        else
                                        {
                                            targetObject2.GetComponent<Node>().concurrentBee_P2++;
                                        }
                                    }
                                    //P2 is sending P2 or P0
                                    else if (targetObject2.GetComponent<Node>().nodeOwner == "P2" || targetObject2.GetComponent<Node>().nodeOwner == "P0")
                                    {
                                        initialObject2.GetComponent<BaseNode>().concurrentSoldierBee--;
                                        
                                        if (targetObject2.GetComponent<Node>().concurrentBee_P1 > 0)
                                        {
                                            targetObject2.GetComponent<Node>().concurrentBee_P1--;
                                        }
                                        else
                                        {
                                            targetObject2.GetComponent<Node>().concurrentBee_P2++;
                                        }
                                    }
                                }
                                
                            }
                        }
                        else
                        {
                            Debug.Log("Not enough soldier in ->> " + initialObject.name);
                        }
                    }

                }
                //if target node resource point
                else if (targetObject2.GetComponent<Node>().NodeType1 == Node.NodeType.Resource)
                {
                    if (Time.time > nextTransferTime)
                    {
                        nextTransferTime = Time.time + transferInterval;
                        if (initialObject2.GetComponent<BaseNode>().concurrentWorkerBee > 0)
                        {
                            if (initialObject2.GetComponent<BaseNode>().BaseOwner == BaseNode.Player.P1)
                            {
                                if (targetObject2 != null)
                                {
                                    //P1 base is sending P1 or P0 node
                                    if (targetObject2.GetComponent<Node>().nodeOwner == "P1" || targetObject2.GetComponent<Node>().nodeOwner == "P0")
                                    {
                                        initialObject2.GetComponent<BaseNode>().concurrentWorkerBee--;
                                        if (targetObject2.GetComponent<Node>().concurrentBee_P2 > 0)
                                        {
                                            targetObject2.GetComponent<Node>().concurrentBee_P2--;
                                        }
                                        else
                                        {
                                            targetObject2.GetComponent<Node>().concurrentBee_P1++;
                                        }

                                        Debug.Log("Transferred Worker Bee: " + initialObject.name + "-->" + targetObject2.name);
                                    }
                                    //P1 base is sending P2 node
                                    else if (targetObject2.GetComponent<Node>().nodeOwner == "P2")
                                    {
                                        initialObject2.GetComponent<BaseNode>().concurrentWorkerBee--;

                                        if (targetObject2.GetComponent<Node>().concurrentBee_P2 > 0)
                                        {
                                            targetObject2.GetComponent<Node>().concurrentBee_P2--;
                                        }
                                        else
                                        {
                                            targetObject2.GetComponent<Node>().concurrentBee_P1++;
                                        }

                                        Debug.Log("Transferred Worker Bee: " + initialObject2.name + "-->" + targetObject2.name);
                                    }
                                }
                            }
                            else if (initialObject2.GetComponent<BaseNode>().BaseOwner == BaseNode.Player.P2)
                            {
                                if (targetObject2 != null)
                                {
                                    //P2 is sending P12
                                    if (targetObject2.GetComponent<Node>().nodeOwner == "P1")
                                    {
                                        initialObject2.GetComponent<BaseNode>().concurrentWorkerBee--;

                                        if (targetObject2.GetComponent<Node>().concurrentBee_P1 > 0)
                                        {
                                            targetObject2.GetComponent<Node>().concurrentBee_P1--;
                                        }
                                        else
                                        {
                                            targetObject2.GetComponent<Node>().concurrentBee_P2++;
                                        }

                                        Debug.Log("Transferred Worker Bee " + initialObject2.name + "-->" + targetObject2.name);
                                    }
                                    //P2 is sending P2 or P0
                                    else if (targetObject2.GetComponent<Node>().nodeOwner == "P2" || targetObject2.GetComponent<Node>().nodeOwner == "P0")
                                    {
                                        initialObject2.GetComponent<BaseNode>().concurrentWorkerBee--;

                                        if (targetObject2.GetComponent<Node>().concurrentBee_P1 > 0)
                                        {
                                            targetObject2.GetComponent<Node>().concurrentBee_P1--;
                                        }
                                        else
                                        {
                                            targetObject2.GetComponent<Node>().concurrentBee_P2++;
                                        }

                                        Debug.Log("Transferred Worker Bee " + initialObject2.name + "-->" + targetObject2.name);
                                    }
                                }
                            }
                        }
                        else
                        {
                            Debug.Log("Not enough worker in ->> " + initialObject2.name);
                        }
                    }
                }
            }
            //Node'dan node'a gonderme
            else if (initialObject2.GetComponent<Node>() != null && targetObject2 != null && targetObject2.GetComponent<Node>() != null && initialObject2.GetComponent<Node>().concurentBee > 0)
            {
                //Debug.Log("NODE TO NODE");
                if (Time.time > nextTransferTime)
                {
                    nextTransferTime = Time.time + transferInterval;
                    //resource to resource point | control to control point check. Example: Dont send soldier to resource point
                    if (initialObject2.GetComponent<Node>().NodeType1 == targetObject2.GetComponent<Node>().NodeType1)
                    {
                        if (initialObject2.GetComponent<Node>().concurentBee > 0)
                        {
                            //P1 is sender
                            if (initialObject2.GetComponent<Node>().nodeOwner == "P1" && initialObject2.GetComponent<Node>().concurrentBee_P1 > 0)
                            {
                                //P1 is sending to P1 or  P0
                                if (targetObject2 != null)
                                {
                                    if (targetObject2.GetComponent<Node>().nodeOwner == "P1" || targetObject2.GetComponent<Node>().nodeOwner == "P0" || targetObject2.GetComponent<Node>().nodeOwner == "P2")
                                    {
                                        initialObject2.GetComponent<Node>().concurrentBee_P1--;

                                        if (targetObject2.GetComponent<Node>().concurrentBee_P2 > 0)
                                        {
                                            targetObject2.GetComponent<Node>().concurrentBee_P2--;
                                        }
                                        else
                                        {
                                            targetObject2.GetComponent<Node>().concurrentBee_P1++;
                                        }

                                        Debug.Log("Transferred Bee :" + initialObject2.name + "-->" + targetObject2.name);
                                    }
                                }
                            }
                            //P2 is sender
                            else if (initialObject2.GetComponent<Node>().nodeOwner == "P2" && initialObject2.GetComponent<Node>().concurrentBee_P2 > 0)
                            {
                                //P2 is sending
                                if (targetObject2 != null)
                                {
                                    if (targetObject2.GetComponent<Node>().nodeOwner == "P1" || targetObject2.GetComponent<Node>().nodeOwner == "P0" || targetObject2.GetComponent<Node>().nodeOwner == "P2")
                                    {
                                        initialObject2.GetComponent<Node>().concurrentBee_P2--;
                                       
                                        if (targetObject2.GetComponent<Node>().concurrentBee_P1 > 0)
                                        {
                                            targetObject2.GetComponent<Node>().concurrentBee_P1--;
                                        }
                                        else
                                        {
                                            targetObject2.GetComponent<Node>().concurrentBee_P2++;
                                        }

                                        Debug.Log("Transferred Bee :" + initialObject2.name + "-->" + targetObject2.name);
                                    }  
                                }
                            }
                        }
                        else
                        {
                            Debug.Log("Not enough Bee in ->> " + initialObject2.name);
                        }
                    }
                    else
                    {
                        Debug.Log("Node type didnt match! " + initialObject2.name + " != " + targetObject2.name);
                    }
                }
            }
            //Node'dan base'e gonderme
            else if (initialObject2.GetComponent<Node>() != null && targetObject2 != null && targetObject2.GetComponent<BaseNode>() != null && initialObject2.GetComponent<Node>().concurentBee > 0)
            {
                //Debug.Log("NODE TO BASEEE");
                //if sender node is control point
                if (initialObject2.GetComponent<Node>().NodeType1 == Node.NodeType.Control)
                {
                    if (Time.time > nextTransferTime)
                    {
                        nextTransferTime = Time.time + transferInterval;
                        if (initialObject2.GetComponent<Node>().concurentBee > 0)
                        {
                            //P1 sending bee to a base
                            if (initialObject2.GetComponent<Node>().nodeOwner == "P1" && initialObject2.GetComponent<Node>().concurrentBee_P1 > 0)
                            {
                                initialObject2.GetComponent<Node>().concurrentBee_P1--;
                                //P1 fallback to own base
                                if (targetObject2.GetComponent<BaseNode>().BaseOwner == BaseNode.Player.P1)
                                {
                                    targetObject2.GetComponent<BaseNode>().concurrentSoldierBee++;
                                }
                                //P1 Attack to P2 base
                                else if (targetObject2.GetComponent<BaseNode>().BaseOwner == BaseNode.Player.P2)
                                {
                                    targetObject2.GetComponent<BaseNode>().concurrentSoldierBee--;
                                }

                                Debug.Log("Transferred Soldier Bee: " + initialObject2.name + "-->" + targetObject2.name);
                            }
                            //P2 sending bee to a base
                            else if (initialObject2.GetComponent<Node>().nodeOwner == "P2" && initialObject2.GetComponent<Node>().concurrentBee_P2 > 0)
                            {
                                initialObject2.GetComponent<Node>().concurrentBee_P2--;
                                //P2 attack to P1 base
                                if (targetObject2.GetComponent<BaseNode>().BaseOwner == BaseNode.Player.P1)
                                {
                                    targetObject2.GetComponent<BaseNode>().concurrentSoldierBee--;
                                }
                                //P2 fallback to own base
                                else if (targetObject2.GetComponent<BaseNode>().BaseOwner == BaseNode.Player.P2)
                                {
                                    targetObject2.GetComponent<BaseNode>().concurrentSoldierBee++;
                                }

                                Debug.Log("Transferred Soldier Bee: " + initialObject.name + "-->" + targetObject2.name);
                            }
                        }
                        else
                        {
                            Debug.Log("Not enough soldier in ->> " + initialObject2.name);
                        }
                    }

                }
                //if sender node is resource point
                else if (initialObject2.GetComponent<Node>().NodeType1 == Node.NodeType.Resource)
                {
                    if (Time.time > nextTransferTime)
                    {
                        nextTransferTime = Time.time + transferInterval;
                        if (initialObject2.GetComponent<Node>().concurentBee > 0)
                        {
                            //P1 sending bee to a base
                            if (initialObject2.GetComponent<Node>().nodeOwner == "P1" && initialObject2.GetComponent<Node>().concurrentBee_P1 > 0)
                            {
                                initialObject2.GetComponent<Node>().concurrentBee_P1--;
                                //P1 fallback to own base
                                if (targetObject2.GetComponent<BaseNode>().BaseOwner == BaseNode.Player.P1)
                                {
                                    targetObject2.GetComponent<BaseNode>().concurrentWorkerBee++;
                                }
                                //P1 Attack to P2 base
                                else if (targetObject2.GetComponent<BaseNode>().BaseOwner == BaseNode.Player.P2)
                                {
                                    targetObject2.GetComponent<BaseNode>().concurrentWorkerBee--;
                                }

                                Debug.Log("Transferred Soldier Bee: " + initialObject2.name + "-->" + targetObject2.name);
                            }
                            //P2 sending bee to a base
                            else if (initialObject2.GetComponent<Node>().nodeOwner == "P2" && initialObject2.GetComponent<Node>().concurrentBee_P2 > 0)
                            {
                                initialObject2.GetComponent<Node>().concurrentBee_P2--;
                                //P2 attack to P1 base
                                if (targetObject2.GetComponent<BaseNode>().BaseOwner == BaseNode.Player.P1)
                                {
                                    targetObject2.GetComponent<BaseNode>().concurrentWorkerBee--;
                                }
                                //P2 fallback to own base
                                else if (targetObject2.GetComponent<BaseNode>().BaseOwner == BaseNode.Player.P2)
                                {
                                    targetObject2.GetComponent<BaseNode>().concurrentWorkerBee++;
                                }

                                Debug.Log("Transferred Soldier Bee: " + initialObject2.name + "-->" + targetObject2.name);
                            }
                        }
                        else
                        {
                            Debug.Log("Not enough worker in ->> " + initialObject2.name);
                        }
                    }
                }
            }
        }
        // Debug.Log("There is a " + underMouseObject + " under your cursor");
    }

    public void Swipe()

    {
        
        for (int i = 0; i < Input.touchCount ; i++)
        {
            
        
            if (Input.touches[i].phase == TouchPhase.Began)
            {
                 id = Input.touches[i].fingerId;
                //save began touch 2d point
                Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
                RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);
    
                if (hit)
                {
                    initialObject = hit.transform.gameObject; //ilk tıkladın elinde bu var
                    Debug.Log("Selected --> " + initialObject);
                    //isFirstClick = true;
                }
            }
    
            if (Input.touches[i].phase == TouchPhase.Ended && Input.touches[i].fingerId == id )
            {
                Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.touches[0].position).x,
                Camera.main.ScreenToWorldPoint(Input.touches[0].position).y);
                RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);
                
    
                if (hit)
                {
                    Debug.Log("Mouse button released");
                }
                
               //reset values
                 //   isFirstClick = false;
                   initialObject = null;
                   targetObject = null;
                
            }
            
        }
    }
    
    
    public void SwipeSecond()

    {
        
        for (int i = 0; i < Input.touchCount ; i++)
        {
            
        
            if (Input.touches[i].phase == TouchPhase.Began)
            {
                id = Input.touches[i].fingerId;
                //save began touch 2d point
                Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                    Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
                RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);
    
                if (hit)
                {
                    initialObject2 = hit.transform.gameObject; //ilk tıkladın elinde bu var
                    Debug.Log("Selected --> " + initialObject);
                    //isFirstClick = true;
                }
            }
    
            if (Input.touches[i].phase == TouchPhase.Ended && Input.touches[i].fingerId == id )
            {
                Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.touches[0].position).x,
                    Camera.main.ScreenToWorldPoint(Input.touches[0].position).y);
                RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);
                
    
                if (hit)
                {
                    Debug.Log("Mouse button released");
                }
                
                //reset values
                //   isFirstClick = false;
                 initialObject2= null;
                 targetObject2 = null;
                
            }
            
        }
    }

    //If there is an object under the cursor, return that game object
    GameObject OnTargetOver()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            
        
            Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.touches[0].position).x,
                         Camera.main.ScreenToWorldPoint(Input.touches[0].position).y);
                         RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);
                         
                         if (hit == true)
                         {
                           //  Debug.Log("There is a hit");
                             return hit.transform.gameObject;
                            
                         }
                         else
                         {
                             return null;
                         }
        }

        return null;
    }

   

    //void ClickSelect()
    //{

    //    if (Input.GetMouseButtonDown(0) && !isFirstClick)
    //    {
    //        //Converting Mouse Pos to 2D (vector2) World Pos
    //        Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
    //            Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
    //        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);

    //        if (hit)
    //        {
    //            Debug.Log(hit.transform.name);
    //            isFirstClick = true;
    //            bee = hit.transform.gameObject;
    //        }

    //    }
    //    else if (Input.GetMouseButtonDown(0) && isFirstClick)
    //    {

    //        Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
    //        Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
    //        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);

    //        if (hit)
    //        {
    //            while ((bee.transform.position - hit.transform.position).magnitude < 0.1f)
    //            {
    //                Vector2 direction = (hit.transform.position - bee.transform.position);
    //                direction.Normalize();
    //                bee.transform.Translate(direction * Time.deltaTime);
    //            }

    //        }
    //        initialObject = null;
    //    }
    //}
}
