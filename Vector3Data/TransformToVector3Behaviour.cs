using UnityEngine;

public class TransformToVector3Behaviour : MonoBehaviour
{
	public Vector3DataCollection collection;
	private void Awake()
	{
		var addPoints = GetComponentsInChildren<Transform>();
		Debug.Log("Found " + addPoints.Length + " points to add to collection " + collection.name);
		collection.TransformToVector3Data(addPoints);
	}
}