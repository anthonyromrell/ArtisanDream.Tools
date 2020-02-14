using UnityEngine;
using UnityEngine.Serialization;

public class DestroyOtherObject : MonoBehaviour
{
	[FormerlySerializedAs("UseOtherCaller")] public bool useOtherCaller;
	private GameObject otherObj;

	public void Call () {
		Destroy(otherObj);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (useOtherCaller)
		{
			otherObj = other.gameObject;
		}
		else
		{
			other.gameObject.SetActive(false);
		}
	}
}
