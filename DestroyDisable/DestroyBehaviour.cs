using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class DestroyBehaviour : MonoBehaviour
{
	[FormerlySerializedAs("Seconds")] public float seconds = 2;
	[FormerlySerializedAs("UseTrigger")] public bool useTrigger = true;
	
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

//	private void OnTriggerEnter(Collider other)
//	{
//		if (UseTrigger)
//		{
//			Destroy(other.gameObject);
//		}
//	}
}