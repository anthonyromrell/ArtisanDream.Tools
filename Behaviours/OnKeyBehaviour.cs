using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class OnKeyBehaviour : MonoBehaviour
{
	[FormerlySerializedAs("Key")] public string key = "a";
	public UnityEvent Event;	
	
	void Update () {
		if (Input.GetKeyDown(key))
		{
			Event.Invoke();
		}
	}
}
