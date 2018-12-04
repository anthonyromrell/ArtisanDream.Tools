using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Objects", menuName = "Store/Objects")]
public class PurchaseableObjects : ScriptableObject
{
	public List<PurchasableObject> ObjectList;
}