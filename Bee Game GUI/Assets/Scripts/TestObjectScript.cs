using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObjectScript : MonoBehaviour 
{
	void Start()
	{
		
	}

	public void HostButtonCaller()
	{
		GameManager.Instance.HostButton ();
	}

	public void JoinButtonCaller()
	{
		GameManager.Instance.JoinButton ();
	}

	public void OptionButtonCaller()
	{
		GameManager.Instance.OptionButton ();
	}

}
