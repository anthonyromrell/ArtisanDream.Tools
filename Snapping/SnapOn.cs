using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace ArtisanDream.Experimental
{
	public class SnapOn : MonoBehaviour
	{
		[FormerlySerializedAs("Speed")] public FloatData speed;
		[FormerlySerializedAs("HoldTime")] public FloatData holdTime;
		private Transform parent;
		private bool canRun = true;
		
		private void OnTriggerEnter(Collider other)
		{
			parent = other.transform;
		}

		public void StartSnap()
		{ 
			StartCoroutine(MoveTo());
			StartCoroutine(Stop());
		}

		private IEnumerator Stop()
		{
			yield return new WaitForSeconds(holdTime.value);
			canRun = false;
		}

		private IEnumerator MoveTo()
		{
			transform.parent = parent;
			
			while (canRun)
			{
				yield return new WaitForFixedUpdate();
				transform.position = Vector3.Lerp(transform.position, parent.position, speed.value);
			}			
		}
	}
}