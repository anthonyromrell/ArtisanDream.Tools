using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnKeyBehaviour : MonoBehaviour
{
	public string Key = "a";
	public UnityEvent Event;	
	
	void Update () {
		if (Input.GetKeyDown(Key))
		{
			Event.Invoke();
		}
	}
}
