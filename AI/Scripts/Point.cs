using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Ai/Point")]
public class Point : ScriptableObject
{
	[FormerlySerializedAs("SendPoint")] public GameAction sendPoint;
	[FormerlySerializedAs("UpdateData")] public UnityEvent updateData;

	private void OnEnable()
	{
		updateData.Invoke();
	}

	public void OnUpdateData(Transform t)
	{
		sendPoint.raise(t);
	}
}
