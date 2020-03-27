using System.Collections.Generic;
using UnityEngine;

public class AddPointsList : MonoBehaviour
{
	private List<Vector3Data> points;
	public GameAction onSendAction;

	private void Awake()
	{
		points = new List<Vector3Data>();
		var addPoints = GetComponentsInChildren<Transform>();
		foreach (var obj in addPoints)
		{
			Vector3Data temp = ScriptableObject.CreateInstance<Vector3Data>();
			temp.value = obj.position;
			points.Add(temp);
		}
		points.RemoveAt(0);
		onSendAction.raise(points);
	}
}