using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class TestModalPanel : MonoBehaviour {

	public Sprite icon;
	private DisplayManager displayManager;
	private ModalPanel modalPanel;
	private UnityAction myYesAction;
	private UnityAction myNoAction;
	private UnityAction myCancelAction;

	void Awake () {
		modalPanel = ModalPanel.Instance();
		displayManager = DisplayManager.Instance ();
		myYesAction = new UnityAction (TestYesFunction);
		myNoAction = new UnityAction (TestNoFunction);
		myCancelAction = new UnityAction(TestCancelFunction);
	}

	//  Send to the Modal Panel to set up the Buttons and functions to call
	public void TestYNC () {
		modalPanel.Choice ("For Alternative 1 Press Yes Button \n For Alternative 2 Press No Button \n None Of Them Press Close Button", TestYesFunction, TestNoFunction, TestCancelFunction);
	}

	public void TestConfirm () {
		modalPanel.Choice ("Do You Want To Confirm It ?", icon, TestYesFunction, TestNoFunction);
	}

	public void TestWarning () {
		modalPanel.Choice ("Warning !", icon, TestCancelFunction);
	}

	//  The function to call when the button is clicked
	//  These are wrapped up in a UnityAction during Awake
	void TestYesFunction () {
		displayManager.DisplayMessage ("Heck, yeah!");
	}

	void TestNoFunction () {
		displayManager.DisplayMessage ("No way, Jose!");
	}

	void TestCancelFunction () {
		displayManager.DisplayMessage ("I give up!");
	}
}