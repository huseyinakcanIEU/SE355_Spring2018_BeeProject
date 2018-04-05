using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefBee : MonoBehaviour
{
	private bool _flag = false;

	private Transform _initPlace;
	public Transform _destination;

	public void Move(Transform init,Transform dest)
	{
		gameObject.transform.position = init.position;
		Debug.Log("Move is called s " + gameObject.name);
		_initPlace = init;
		_destination = dest;
		_flag = true;
	}
		
	// Update is called once per frame
	void Update()
	{
		if (_flag)
		{
			Debug.Log("Moving from " + transform.position + "Moving to " + _destination.position);
			transform.position = Vector2.MoveTowards(transform.position, _destination.position, 10f * Time.deltaTime);
			if ((_destination.position - transform.position).magnitude < 1)
			{
				Destroy(gameObject);
			}
		}
		
	}
}
