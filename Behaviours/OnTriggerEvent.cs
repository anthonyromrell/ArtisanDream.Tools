using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEvent : MonoBehaviour
{

	public UnityEvent Event;
	
	private void OnTriggerEnter(Collider other)
	{
		Event.Invoke();
	}
}
