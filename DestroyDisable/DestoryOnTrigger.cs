using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryOnTrigger : MonoBehaviour
{
	public float holdTime = 0.1f;

	private IEnumerator OnTriggerEnter(Collider other)
	{
		yield return new WaitForSeconds(holdTime);
		Destroy(gameObject);
	}
}