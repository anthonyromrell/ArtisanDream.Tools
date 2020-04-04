using UnityEngine;

[CreateAssetMenu(menuName = "System/Vector3DataSystem")]
public class Vector3DataSystem : ScriptableObject
{
    public Vector3DataList currentList;
    public Vector3DataList holdList;
    public int currentInUseNum;

    public void RandomizeNum()
    {
        var newNum = Random.Range(0, currentList.vector3Datas.Count - 1);
        currentInUseNum = newNum;
    }

    public void MoveListItem(Vector3DataList listA, Vector3DataList listB)
    {
        var currentObj = listA.vector3Datas[currentInUseNum];
        listB.vector3Datas.Add(currentObj);
        listA.vector3Datas.RemoveAt(currentInUseNum);
    }
    
    public void MoveToCurrentList()
    {
        var currentObj = currentList.vector3Datas[currentInUseNum];
        currentList.vector3Datas.Add(currentObj);
        holdList.vector3Datas.RemoveAt(currentInUseNum);
    }
    
    public void MoveToCurrentList(Vector3Data currentObj)
    {
        currentList.vector3Datas.Add(currentObj);
    }

    public void MoveToHoldList()
    {
        var currentObj = currentList.vector3Datas[currentInUseNum];
        holdList.vector3Datas.Add(currentObj);
        currentList.vector3Datas.RemoveAt(currentInUseNum);
    }
    
    public Vector3Data MoveFromCurrentList()
    {
        var currentObj = currentList.vector3Datas[currentInUseNum];
        currentList.vector3Datas.RemoveAt(currentInUseNum);
        return currentObj;
    }

    public Vector3 ReturnCurrentVector3()
    {
        return currentList.vector3Datas[currentInUseNum].value;
    }

    public Vector3 ReturnRandomVector3()
    {
        RandomizeNum();
        var obj = ReturnCurrentVector3();
        return obj;
    }

    public void ClearAll()
    {
        currentList.vector3Datas.Clear();
        holdList.vector3Datas.Clear();
    }
}