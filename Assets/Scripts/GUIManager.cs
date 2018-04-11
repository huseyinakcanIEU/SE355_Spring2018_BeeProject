using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour 
{

	public GameObject optpanel;
	public GameObject panelWarning;
	public GameObject panelConfirm;
	public GameObject panelAlternative;

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

	public void WarningButton()
	{
		Debug.Log ("Warning Button called");
		panelConfirm.gameObject.SetActive (false);
		panelAlternative.gameObject.SetActive (false);
		panelWarning.gameObject.SetActive (true);
	}

	public void ConfirmButton()
	{
		Debug.Log ("Confirm Button called");
		panelWarning.gameObject.SetActive (false);
		panelAlternative.gameObject.SetActive (false);
		panelConfirm.gameObject.SetActive (true);
	}

	public void AlternativeButton()
	{
		Debug.Log ("Alternative Button called");
		panelWarning.gameObject.SetActive (false);
		panelConfirm.gameObject.SetActive (false);
		panelAlternative.gameObject.SetActive (true);
	}

	void Awake()
	{
		_instance = this;
	}

}
