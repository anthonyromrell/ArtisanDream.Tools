using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
	public FloatBase HealthLevel;
	public FloatBase EvilPower;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter ()
	{
		HealthLevel.Value -= EvilPower.Value;
	}
}
