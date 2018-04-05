using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

    public InputField _beeText;

    public string _input;

    public void SetText() {
       _input = _beeText.text;        
    }

}
