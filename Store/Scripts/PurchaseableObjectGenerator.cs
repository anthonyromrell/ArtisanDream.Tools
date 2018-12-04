using System;
using UnityEngine;

public class PurchaseableObjectGenerator : MonoBehaviour
{
	public PurchaseableObjects Purchased;

	public enum States
	{
		CreateAllNow,
		CreateAllAtLocation,
		CreateAllAndParent,
		CreateOnceAtLocation,
		CreateOnceAndParent
	}

	public States CreateOnState = States.CreateOnceAndParent;
	
	void Start ()
	{
		for (var i = 0; i < Purchased.ObjectList.Count; i++)
		{
			var obj = Purchased.ObjectList[i];
			switch (CreateOnState)
			{
				case States.CreateAllNow:
					obj.OnCreate.AddListener(obj.CreateItems);
					break;
				case States.CreateAllAtLocation:
					obj.OnCreate.AddListener(obj.CreateItemsAtLocation);
					break;
				case States.CreateAllAndParent:
					obj.OnCreate.AddListener(obj.CreateItemsOnParent);
					break;
				case States.CreateOnceAtLocation:
					obj.OnCreate.AddListener(obj.CreateOnceAtLocation);
					break;
				case States.CreateOnceAndParent:
					obj.OnCreate.AddListener(obj.CreateOnceAndParent);
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
			
			obj.OnCreate.Invoke();
			
			if (!obj.Perpetual && obj.UsageCount == 0)
			{
				Purchased.ObjectList.Remove(obj);
			}
		}
	}
}