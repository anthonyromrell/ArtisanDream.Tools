using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//Made By Anthony Romrell
namespace ArtisanDream.Experimental.Counter
{
	public class RunCountDown : MonoBehaviour
	{
		public float Seconds = 1.0f;
		public int Number = 3;
		private Text label;
	
		IEnumerator Start ()
		{
			label = GetComponent<Text>();

			while (Number > 0)
			{
		    
				yield return new WaitForSeconds(Seconds);
				label.text = Number.ToString();
				Number--;
			}
			//label.text = "";
			yield return new WaitForSeconds(1);
			label.text = "GO!";
		}

		private IEnumerator OnTriggerEnter(Collider other)
		{
			yield return new WaitForSeconds(5);
		}
	}
}