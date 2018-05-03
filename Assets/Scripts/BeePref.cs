using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeePref : MonoBehaviour {

	public void Movement(List<Vertex> _path){
		StartCoroutine (GoTo (_path));
	}

	public IEnumerator GoTo(List<Vertex> _path){
		for (int i = 0; i < _path.Count; i++) {
			yield return StartCoroutine (SingleMove(_path,i));
		}
	}

	public IEnumerator SingleMove(List<Vertex> _path,int i){
		while (true) {
			transform.position = Vector2.MoveTowards (transform.position, _path [i].gameObject.transform.position, 3f);
			if (transform.position == _path [i].gameObject.transform.position) {
				yield break;
			}
		}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
}
