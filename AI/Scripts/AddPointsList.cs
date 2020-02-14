using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

//Made By Anthony Romrell
public class AddPointsList : MonoBehaviour
{

	private List<Vector3Data> points;
	[FormerlySerializedAs("PointObjects")] public List<Transform> pointObjects;
	
	[FormerlySerializedAs("OnSendAction")] public GameAction onSendAction;

	private void Start()
	{
		points = new List<Vector3Data>();
		foreach (var obj in pointObjects)
		{
			UpdateInfo(obj);
		}
		SendAction();
	}

	public void UpdateInfo(Transform t)
	{
		Vector3Data temp = ScriptableObject.CreateInstance<Vector3Data>();
		temp.value = t.position;
		points.Add(temp);
	}

	public void SendAction()
	{
		onSendAction.raise(points);
		print(points);
	}
}
