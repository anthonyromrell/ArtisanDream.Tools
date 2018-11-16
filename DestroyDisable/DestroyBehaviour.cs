using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBehaviour : MonoBehaviour
{
	public float Seconds = 2;
	public bool UseTrigger = true;
	
	IEnumerator Start () {
		yield return new WaitForSeconds(Seconds);
		Destroy(gameObject);
	}

	public void DestroyObj()
	{
		Destroy(gameObject);
	}

	public void DestroyAny(Object obj)
	{
		Destroy(obj);
	}

//	private void OnTriggerEnter(Collider other)
//	{
//		if (UseTrigger)
//		{
//			Destroy(other.gameObject);
//		}
//	}
}