using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{

	public GameObject optpanel;

	public AudioSource music;

	private static GameManager _instance;

	public static GameManager Instance 
	{

		get 
		{

			if (_instance == null) 
			{
				GameObject go = new GameObject ("Game Manager");
				go.AddComponent<GameManager> ();
			}

			return _instance;

		}

	}

	public void HostButton()
	{
		Debug.Log ("Host Button called");
	}

	public void JoinButton()
	{
		Debug.Log ("Join Button called");
	}

	public void OptionButton()
	{
		Debug.Log ("Option Button called");
		optpanel.gameObject.SetActive (true);

	}

	public void OptionDoneButton()
	{
		Debug.Log ("Option Done Button called");
		optpanel.gameObject.SetActive (false);

	}

	public void MusicButton()
	{
		Debug.Log ("Music Button called");
		music.mute = !music.mute;

	}


	void Awake()
	{
		_instance = this;
	}

}
