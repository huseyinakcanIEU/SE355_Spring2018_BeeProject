using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public GameObject gameOverUI;
	public Text timerText;
	private float startTime;
	public int _min = 2;
	private int _sec = 59;

	private void Awake()
	{
		timerText = GameObject.FindGameObjectWithTag("Timer").GetComponent<Text>();
	}

	// Use this for initialization
	void Start ()
	{
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		float t = Time.time;
		int minutes = (int) (t / 60);
		int seconds = (int)(t % 60);

		if (_min - minutes < 0)
		{
			gameOverUI.SetActive(true);
			Destroy(gameObject);
			// call game over
		}
		
		string min = (_min - minutes).ToString();
		string sec = (_sec - seconds).ToString();

		timerText.text = min + ":" + sec;
		if (_sec - seconds < 10)
		{
			timerText.text = min + ":0" + sec;

		}
		
		
	}
}
