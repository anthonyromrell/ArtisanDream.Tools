using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Objects", menuName = "Store/Objects")]
public class PurchaseableObjects : ScriptableObject
{
	[FormerlySerializedAs("ObjectList")] public List<Object> objectList;	
	[FormerlySerializedAs("PurchasableList")] public List<ICanBePurchased> purchasableList;

	private void OnEnable()
	{
		purchasableList = new List<ICanBePurchased>();
		foreach (var item in objectList)
		{
			var newItem = item as ICanBePurchased;
			purchasableList.Add(newItem);
		}
	}
}