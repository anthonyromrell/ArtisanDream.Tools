using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public abstract class AiBase : ScriptableObject
{
	[FormerlySerializedAs("Speed")] public FloatData speed;
	[FormerlySerializedAs("AngularSpeed")] public FloatData angularSpeed;
	public abstract IEnumerator Nav(NavMeshAgent ai);
}
