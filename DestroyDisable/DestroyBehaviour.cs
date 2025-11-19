using System.Collections;
using UnityEngine;

public class DestroyBehaviour : MonoBehaviour
{
	public float seconds = 2;
	public bool useTrigger;
	
	private IEnumerator Start () {
		yield return new WaitForSeconds(seconds);
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

	private void OnTriggerEnter(Collider other)
	{
		if (useTrigger)
		{
			Destroy(other.gameObject);
		}
	}
}