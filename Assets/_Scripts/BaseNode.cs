using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseNode : MonoBehaviour {
    public UIManager _uiManager;
    private Bee _bee;
    
    
    public int _health;
    public int _honeyStock;

    public int _maxQuota;
    public int _soldierBeeCost;
    public int _workerBeeCost;

    private List<GameObject> _resourceList;



    public void createSoldierBee()
    {
        if(_honeyStock>= _soldierBeeCost && _bee.GetQuota() < _maxQuota)
        {
            _honeyStock -= _soldierBeeCost;
            _bee.SetSoldierBeeNumber(_bee.GetSoldierBeeNumber() + 1);
            _bee.SetQuota(_bee.GetQuota() + 1);
        }
        else { Debug.Log("Soldier creation error;");}
    }

    public void createWorkerBee()
    {
        if (_honeyStock >= _workerBeeCost && _bee.GetQuota() < _maxQuota)
        {
            _honeyStock -= _workerBeeCost;
            _bee.SetWorkerBeeNumber(_bee.GetWorkerBeeNumber() + 1);
            _bee.SetQuota(_bee.GetQuota() + 1);
        }
        else { Debug.Log("Worker creation error;"); }

    }

    private void AddHoneyStock()
    {
        Debug.Log("Adding honey stock:" + _honeyStock);
        _honeyStock += 5;
    }

    //Need to now who has how many bees in a particular resource.
    //Worker and Soldier bees need to be an object with an attribute to keep track of the owner of them...
    private void AddHoneyStockWithWorkerBee()
    {
        _resourceList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Resource"));
        foreach(var go in _resourceList)
        {
            Debug.Log("Working forEach");
            //go.GetComponent<>
        }
    }

    private void OnMouseDown()
    {
        _uiManager.Highlight(gameObject);
    }

    private void Awake()
    {
        _bee = GetComponent<Bee>();
        _uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
    }

    // Use this for initialization
    void Start () {

        //Increasing _honeyStock 5 per second.
        InvokeRepeating("AddHoneyStock", 1, 1);
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
