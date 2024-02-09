using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StringListManager : ScriptableObject
{
    [SerializeField] private List<StringList> stringListDatas;

    [SerializeField] private int currentListNum;

    private StringList CurrentListData
    {
        get => stringListDatas != null && currentListNum < stringListDatas.Count
            ? stringListDatas[currentListNum]
            : null;
    }

    public void IncrementListNum()
    {
        if (stringListDatas != null && stringListDatas.Count > 0)
        {
            currentListNum = (currentListNum + 1) % stringListDatas.Count;
        }
    }

    public void UseNextListOnEnd()
    {
        if (CurrentListData != null && CurrentListData.CurrentLineNumber == CurrentListData.stringListObj.Count - 1)
        {
            IncrementListNum();
        }
    }
}