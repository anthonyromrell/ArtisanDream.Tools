using System;
using UnityEngine;
using UnityEngine.Serialization;

public class PurchaseableObjectGenerator : MonoBehaviour
{
	[FormerlySerializedAs("Purchased")] public PurchaseableObjects purchased;

	public enum States
	{
		CreateAllNow,
		CreateAllAtLocation,
		CreateAllAndParent,
		CreateOnceAtLocation,
		CreateOnceAndParent
	}

	[FormerlySerializedAs("CreateOnState")] public States createOnState = States.CreateOnceAndParent;
	
	void Start ()
	{
		for (var i = 0; i < purchased.objectList.Count; i++)
		{
			var obj = purchased.objectList[i] as InGamePurchase;
			switch (createOnState)
			{
				case States.CreateAllNow:
					obj.onCreate.AddListener(obj.CreateItems);
					break;
				case States.CreateAllAtLocation:
					obj.onCreate.AddListener(obj.CreateItemsAtLocation);
					break;
				case States.CreateAllAndParent:
					obj.onCreate.AddListener(obj.CreateItemsOnParent);
					break;
				case States.CreateOnceAtLocation:
					obj.onCreate.AddListener(obj.CreateOnceAtLocation);
					break;
				case States.CreateOnceAndParent:
					obj.onCreate.AddListener(obj.CreateOnceAndParent);
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
			
			obj.onCreate.Invoke();
			
			if (!obj.perpetual && obj.usageCount == 0)
			{
				purchased.objectList.Remove(obj);
			}
		}
	}
}