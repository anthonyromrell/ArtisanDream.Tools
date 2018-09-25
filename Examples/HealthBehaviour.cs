using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBehaviour : MonoBehaviour
{
	public FloatBase HealthLevel;
	private Image HealthImage;
	
	// Use this for initialization
	void Start ()
	{
		HealthImage = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		HealthImage.fillAmount = HealthLevel.Value;
	}
}