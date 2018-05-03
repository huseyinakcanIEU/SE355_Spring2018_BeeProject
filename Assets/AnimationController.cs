using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    private Animator myAnimator;

    // Use this for initialization
    void Start () {
        myAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Q))
        {    
            //myAnimator.SetBool("attack",true);
            myAnimator.SetTrigger("attack");
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            myAnimator.SetTrigger("death");
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            myAnimator.SetTrigger("idle");
        }
        //Örümcek
        else if (Input.GetKeyDown(KeyCode.A))
        {
            myAnimator.SetTrigger("spdAttack");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            myAnimator.SetTrigger("spdDeath");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            myAnimator.SetTrigger("spdIdle");
        }
        //SoldierAlien
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            myAnimator.SetTrigger("soldAttack");
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            myAnimator.SetTrigger("soldDeath");
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            myAnimator.SetTrigger("soldIdle");
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            myAnimator.SetTrigger("soldDamage");
        }
    }
}
