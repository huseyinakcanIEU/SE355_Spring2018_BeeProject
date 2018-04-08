using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour 
{

	public GameObject optpanel;

	public AudioSource music;

    public Text musicText;

	private static GUIManager _instance;

	public static GUIManager Instance 
	{

		get 
		{

			if (_instance == null) 
			{
				GameObject go = new GameObject ("Game Manager");
				go.AddComponent<GUIManager> ();
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
        if(music.mute)
        {
            musicText.text = "Music: Off";
        }
        else
        {
            musicText.text = "Music: On";
        }

	}

	public void ButtonClickDebug(string text)
	{
		Debug.Log (text + " button clicked");
	}



	void Awake()
	{
		_instance = this;
	}

}
