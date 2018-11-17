using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryOnTrigger : MonoBehaviour
{
	public bool useTrigger;

	public bool UseTrigger
	{
		get => useTrigger;
		set => useTrigger = value;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (UseTrigger)
		{
			Destroy(other.gameObject);
		}
	}
}