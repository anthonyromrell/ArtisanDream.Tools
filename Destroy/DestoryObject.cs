using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryObject : MonoBehaviour
{
	public bool UseTrigger;
	
	public void Call()
	{
		Destroy(gameObject);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (UseTrigger)
		{
			Destroy(gameObject);
		}
	}
}