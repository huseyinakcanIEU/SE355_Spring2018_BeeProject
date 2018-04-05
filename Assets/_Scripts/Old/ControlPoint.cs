using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPoint : MonoBehaviour {

    public UIManager _uiManager;

    public int _health;
    public int _soldierBeeNumber;
    public Vector2 _location;



    private void OnMouseDown()
    {
        _uiManager.Highlight(gameObject);
    }


    private void Awake()
    {
        _uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
