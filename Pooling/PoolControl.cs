using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pool Control")]
public class PoolControl : ScriptableObject
{

	public List<GameObject> avaliablePoolObjs;
	
	public void ActivateObj(Vector3 transformPosition)
	{
		if (avaliablePoolObjs.Count <= 0) return;
		avaliablePoolObjs[0].transform.position = transformPosition;
		avaliablePoolObjs[0].SetActive(true);
		avaliablePoolObjs.RemoveAt(0);
	}

	public void AddObj(GameObject obj)
	{
		avaliablePoolObjs.Add(obj);
	}

	public void RemoveObj(GameObject obj)
	{
		avaliablePoolObjs.Remove(obj);
	}

	private void OnDisable()
	{
		avaliablePoolObjs.Clear();
	}
}
