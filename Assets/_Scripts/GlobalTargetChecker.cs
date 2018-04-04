using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalTargetChecker : MonoBehaviour {
    public UIManager _uiManager;


    //if its target enable targetUI in update()
    public bool isTarget = false;



    private void Awake()
    {
        _uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isTarget)
        {
            Debug.Log("lol + " + gameObject.name);
            _uiManager.ShowTargetUI(gameObject);
            isTarget = false;
        }
	}
}
