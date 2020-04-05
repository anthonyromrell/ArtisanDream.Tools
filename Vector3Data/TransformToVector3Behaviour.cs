using UnityEngine;

public class TransformToVector3Behaviour : MonoBehaviour
{
	public Vector3DataCollection collection;
	private void Awake()
	{
		var addPoints = GetComponentsInChildren<Transform>();
		collection.TransformToVector3Data(addPoints);
	}
}