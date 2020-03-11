using System.Collections;
using UnityEngine;

public class SnapBehaviour : MonoBehaviour
	{
		public FloatData speed;
		public FloatData holdTime;
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