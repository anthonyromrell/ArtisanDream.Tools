using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public abstract class AiBase : ScriptableObject
{
	public FloatData Speed;
	public FloatData AngularSpeed;
	public abstract IEnumerator Nav(NavMeshAgent ai);
}
