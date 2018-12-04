using System.Collections.Generic;
using UnityEngine;

//Made By Anthony Romrell
public class AddPointsList : MonoBehaviour
{

	private List<Vector3Data> points;
	public List<Transform> PointObjects;
	
	public GameAction OnSendAction;

	private void Start()
	{
		points = new List<Vector3Data>();
		foreach (var obj in PointObjects)
		{
			UpdateInfo(obj);
		}
		SendAction();
	}

	public void UpdateInfo(Transform t)
	{
		Vector3Data temp = ScriptableObject.CreateInstance<Vector3Data>();
		temp.Value = t.position;
		points.Add(temp);
	}

	public void SendAction()
	{
		OnSendAction.Raise(points);
	}
}
