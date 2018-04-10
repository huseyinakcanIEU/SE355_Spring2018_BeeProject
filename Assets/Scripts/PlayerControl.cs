using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    private GameObject bee;

    public bool isFirstClick = false;
    public int transferInterval = 1; //1 second
    private float nextTransferTime = 0;

    public GameObject underMouseObject;
    public GameObject initialObject; //first selected
    public GameObject targetObject; //second selected 

    void Update()
    {
        Swipe();
        underMouseObject = OnTargetOver(); //update what is under cursor
        TransferBee();
    }

    private void TransferBee()
    {
        //hedef node'u belirle
        if (isFirstClick == true && underMouseObject != initialObject)
        {
            targetObject = underMouseObject;
            //kosullar uygunsa ari gonder

            //Base'den node'a gondermeyi dene
            if (initialObject.GetComponent<BaseNode>() != null && targetObject != null && targetObject.GetComponent<Node>() != null && initialObject.GetComponent<BaseNode>().concurrentBee > 0)
            {
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
                                    ////P1 is sending to P2
                                    //else if (targetObject.GetComponent<Node>().nodeOwner == "P2")
                                    //{
                                    //    initialObject.GetComponent<Node>().concurrentBee_P1--;

                                    //    if (targetObject.GetComponent<Node>().concurrentBee_P2 > 0)
                                    //    {
                                    //        targetObject.GetComponent<Node>().concurrentBee_P2--;
                                    //    }
                                    //    else
                                    //    {
                                    //        targetObject.GetComponent<Node>().concurrentBee_P1++;
                                    //    }

                                    //    Debug.Log("Transferred Bee :" + initialObject.name + "-->" + targetObject.name);
                                    //}
                                }
                            }
                            //P2 is sender
                            else if (initialObject.GetComponent<Node>().nodeOwner == "P2" && initialObject.GetComponent<Node>().concurrentBee_P2 > 0)
                            {
                                //P2 is sending to P1
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
                if (initialObject.GetComponent<Node>().NodeType1 == Node.NodeType.Control)
                {
                    if (Time.time > nextTransferTime)
                    {
                        nextTransferTime = Time.time + transferInterval;
                        if (initialObject.GetComponent<Node>().concurentBee > 0)
                        {
                            if (initialObject.GetComponent<Node>().nodeOwner == "P1" && initialObject.GetComponent<Node>().concurrentBee_P1 > 0)
                            {
                                initialObject.GetComponent<Node>().concurrentBee_P1--;
                                targetObject.GetComponent<BaseNode>().concurrentSoldierBee++;
                            }
                            else if (initialObject.GetComponent<Node>().nodeOwner == "P2" && initialObject.GetComponent<Node>().concurrentBee_P2 > 0)
                            {
                                initialObject.GetComponent<Node>().concurrentBee_P2--;
                                targetObject.GetComponent<BaseNode>().concurrentSoldierBee++;
                            }

                            Debug.Log("Transferred Soldier Bee: " + initialObject.name + "-->" + targetObject.name);
                        }
                        else
                        {
                            Debug.Log("Not enough soldier in ->> " + initialObject.name);
                        }
                    }

                }
                else if (initialObject.GetComponent<Node>().NodeType1 == Node.NodeType.Resource)
                {
                    if (Time.time > nextTransferTime)
                    {
                        nextTransferTime = Time.time + transferInterval;
                        if (initialObject.GetComponent<Node>().concurentBee > 0)
                        {
                            if (initialObject.GetComponent<Node>().nodeOwner == "P1" && initialObject.GetComponent<Node>().concurrentBee_P1 > 0)
                            {
                                initialObject.GetComponent<Node>().concurrentBee_P1--;
                                targetObject.GetComponent<BaseNode>().concurrentWorkerBee++;
                            }
                            else if (initialObject.GetComponent<Node>().nodeOwner == "P2" && initialObject.GetComponent<Node>().concurrentBee_P2 > 0)
                            {
                                initialObject.GetComponent<Node>().concurrentBee_P2--;
                                targetObject.GetComponent<BaseNode>().concurrentWorkerBee++;
                            }
                            Debug.Log("Transferred Worker Bee " + initialObject.name + "-->" + targetObject.name);
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

    public void Swipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //save began touch 2d point
            Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);

            if (hit)
            {
                initialObject = hit.transform.gameObject; //ilk tıkladın elinde bu var
                Debug.Log("Selected --> " + initialObject);
                isFirstClick = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);

            if (hit)
            {
                Debug.Log("Mouse button released");
            }
            
            //reset values
            isFirstClick = false;
            initialObject = null;
            targetObject = null;
        }
    }

    //If there is an object under the cursor, return that game object
    GameObject OnTargetOver()
    {
        Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
        Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);
        
        if (hit == true)
        {
            return hit.transform.gameObject;
        }
        else
        {
            return null;
        }
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
