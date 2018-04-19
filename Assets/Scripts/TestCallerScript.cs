using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCallerScript : MonoBehaviour 
{
	void Start()
	{
		
	}

	public void HostButtonCaller()
	{
		GUIManager.Instance.HostButton ();
	}

	public void JoinButtonCaller()
	{
		GUIManager.Instance.JoinButton ();
	}

	public void OptionButtonCaller()
	{
		GUIManager.Instance.OptionButton ();
	}

	public void OptionDoneButtonCaller()
	{
		GUIManager.Instance.OptionDoneButton ();
	}

	public void MusicButtonCaller()
	{
		GUIManager.Instance.MusicButton ();
	}

	public void WarningButtonCaller()
	{
		GUIManager.Instance.WarningButton ();
	}

	public void ConfirmationButtonCaller()
	{
		GUIManager.Instance.ConfirmButton ();
	}

	public void AlternativeButtonCaller()
	{
		GUIManager.Instance.AlternativeButton ();
	}
}
