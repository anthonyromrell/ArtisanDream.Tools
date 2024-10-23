using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Color/Generator")]
public class ColorGenerator : ScriptableObject, ICreate
{
	public List<NameId> Id;
	public List<ColorData> ObjColor;
	public GameObject RingPrefab, DotPrefab;
	public GameActionAdvanced GetDotPoints, GetRingPoints;
	private List<Vector3Data> dotStartPoints, ringStartPoints;
	public int I { get; set; }

	public void OnEnable()
	{
		I = 0;
		GetDotPoints.Raise = RaiseDotHandler;
		GetRingPoints.Raise = RaiseRingHandler;
	}

	private void RaiseDotHandler(object dotList)
	{
		dotStartPoints = dotList as List<Vector3Data>;
	}
	
	private void RaiseRingHandler(object dotList)
	{
		ringStartPoints = dotList as List<Vector3Data>;
	}

	public void Create()
	{
		Build(RingPrefab, ringStartPoints, ringStartPoints.Count);
		Build(DotPrefab, dotStartPoints, dotStartPoints.Count);
		
		if (I < ObjColor.Count-1)
		{
			I++;
		}
		else
		{
			I = 0;
		}
	}

	public void Build(GameObject obj, Vector3 location)
	{
		var newGo = Instantiate(obj, location, Quaternion.identity);
		newGo.GetComponent<MatchIdBehaviour>().nameIdObj = Id[I];
		newGo.GetComponentInChildren<SpriteRenderer>().color = ObjColor[I].Value;
	}
	
	public void Build(GameObject obj, List<Vector3Data> points, int count)
	{
		var num = Mathf.RoundToInt(Random.Range(0, count));
		if (points[num] != null)
		{
			var location = points[num].value;
			var newGo = Instantiate(obj, location, Quaternion.identity);
			newGo.GetComponent<MatchIdBehaviour>().nameIdObj = Id[I];
			newGo.GetComponentInChildren<SpriteRenderer>().color = ObjColor[I].Value;
		}
	}
}

public interface ICreate
{
	int I { get; set; }
	void OnEnable();
	void Create();
	void Build(GameObject go, Vector3 location);
}