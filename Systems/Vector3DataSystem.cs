using UnityEngine;

[CreateAssetMenu(menuName = "System/Vector3DataSystem")]
public class Vector3DataSystem : ScriptableObject
{
    public Vector3DataCollection currentList;
    public Vector3DataCollection holdList;
    public int index;

    public void RandomizeNum()
    {
        index = Random.Range(0, currentList.vector3Datas.Count - 1);
    }

    public void MoveListItem(Vector3DataCollection listA, Vector3DataCollection listB)
    {
        var currentObj = listA.vector3Datas[index];
        listB.vector3Datas.Add(currentObj);
        listA.vector3Datas.RemoveAt(index);
    }
    
    public void MoveToCurrentList()
    {
        var currentObj = currentList.vector3Datas[index];
        currentList.vector3Datas.Add(currentObj);
        holdList.vector3Datas.RemoveAt(index);
    }
    
    public void MoveToCurrentList(Vector3Data currentObj)
    {
        currentList.vector3Datas.Add(currentObj);
    }

    public void MoveToHoldList()
    {
        var currentObj = currentList.vector3Datas[index];
        holdList.vector3Datas.Add(currentObj);
        currentList.vector3Datas.RemoveAt(index);
    }
    
    public Vector3Data MoveFromCurrentList()
    {
        var currentObj = currentList.vector3Datas[index];
        currentList.vector3Datas.RemoveAt(index);
        return currentObj;
    }

    public Vector3 ReturnCurrentVector3()
    {
        return currentList.vector3Datas[index].value;
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