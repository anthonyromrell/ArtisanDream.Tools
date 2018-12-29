using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Objects", menuName = "Store/Objects")]
public class PurchaseableObjects : ScriptableObject
{
	public List<Object> ObjectList;	
	public List<ICanBePurchased> PurchasableList;

	private void OnEnable()
	{
		PurchasableList = new List<ICanBePurchased>();
		foreach (var item in ObjectList)
		{
			var newItem = item as ICanBePurchased;
			PurchasableList.Add(newItem);
		}
	}
}