using System.Collections;
using UnityEngine;

namespace ArtisanDream.Experimental
{
	public class SnapOn : MonoBehaviour
	{
		public FloatData Speed;
		public FloatData HoldTime;
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
			yield return new WaitForSeconds(HoldTime.Value);
			canRun = false;
		}

		private IEnumerator MoveTo()
		{
			transform.parent = parent;
			
			while (canRun)
			{
				yield return new WaitForFixedUpdate();
				transform.position = Vector3.Lerp(transform.position, parent.position, Speed.Value);
			}			
		}
	}
}