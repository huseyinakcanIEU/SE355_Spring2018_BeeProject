using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    private GameObject bee;

    public bool isFirstClick = false;

    public GameObject underMouseObject;
    public GameObject initialObject; //first selected
    public GameObject targetObject; //second selected 

    void Update()
    {
        Swipe();
        underMouseObject = OnTargetOver();
        if (isFirstClick == true && underMouseObject != initialObject)
        {
            targetObject = underMouseObject;
        }


        // Debug.Log("There is a " + underMouseObject + " under your cursor");
        //ClickSelect();
        //SetTarget();
    }





    public void Swipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //save began touch 2d point
            //firstPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);

            Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);

            if (hit)
            {
                Debug.Log("Seçtim");
                initialObject = hit.transform.gameObject; //ilk tıkladın elinde bu var
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
                Debug.Log("Bıraktım");
            }
            
            //reset values
            isFirstClick = false;
            initialObject = null;

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


    void ClickSelect()
    {

        if (Input.GetMouseButtonDown(0) && !isFirstClick)
        {
            //Converting Mouse Pos to 2D (vector2) World Pos
            Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);

            if (hit)
            {
                Debug.Log(hit.transform.name);
                isFirstClick = true;
                bee = hit.transform.gameObject;
            }

        }
        else if (Input.GetMouseButtonDown(0) && isFirstClick)
        {

            Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);

            if (hit)
            {
                while ((bee.transform.position - hit.transform.position).magnitude < 0.1f)
                {
                    Vector2 direction = (hit.transform.position - bee.transform.position);
                    direction.Normalize();
                    bee.transform.Translate(direction * Time.deltaTime);
                }

            }
            initialObject = null;
        }
    }
}
