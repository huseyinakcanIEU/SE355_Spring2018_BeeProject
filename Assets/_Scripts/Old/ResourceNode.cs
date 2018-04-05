using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceNode : MonoBehaviour {
    public UIManager _uiManager;

    // honey rate per worker bee
    [SerializeField]
    private int _stockRatio;

    public Vector2 _location;
    public int _workerBeeNumberP1;
    public int _workerBeeNumberP2;


    public void SetStockRatio(int stockRatio) {
        _stockRatio = stockRatio;
    }

    public int GetStockRatio()
    {
        return _stockRatio;
    }

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
