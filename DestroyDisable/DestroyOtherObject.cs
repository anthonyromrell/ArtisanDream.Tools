using UnityEngine;

public class DestroyOtherObject : MonoBehaviour
{
	public bool UseOtherCaller;
	private GameObject otherObj;

	public void Call () {
		Destroy(otherObj);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (UseOtherCaller)
		{
			otherObj = other.gameObject;
		}
		else
		{
			other.gameObject.SetActive(false);
		}
	}
}
