using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GetConsoleMessage : MonoBehaviour {

	public void onButtonClick()
	{
		if (EventSystem.current.currentSelectedGameObject != null) {
			Debug.Log ("Clicked on : " + EventSystem.current.currentSelectedGameObject.name);
		}
	}
}
