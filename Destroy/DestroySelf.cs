using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
	public float HoldTime = 2;
	IEnumerator Start () {
		yield return new WaitForSeconds(HoldTime);
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
}