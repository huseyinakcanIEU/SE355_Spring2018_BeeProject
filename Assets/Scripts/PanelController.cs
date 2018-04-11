using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour {

	public GameObject panelWarning;
	public GameObject panelConfirm;
	public GameObject panelAlternative;

	private static PanelController _instance;

	public static PanelController Instance 
	{

		get 
		{

			if (_instance == null) 
			{
				GameObject go = new GameObject ("Game Manager");
				go.AddComponent<PanelController> ();
			}

			return _instance;

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
