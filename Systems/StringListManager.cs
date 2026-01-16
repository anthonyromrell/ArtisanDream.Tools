using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StringListManager : ScriptableObject
{
    [SerializeField] private List<StringList> stringLists;
    [SerializeField] private int currentListNum;
    private StringList CurrentListData => stringLists?[currentListNum];

    private void IncrementListNum()
    {
        if (stringLists != null && stringLists.Count > 0)
        {
            currentListNum = (currentListNum + 1) % stringLists.Count;
        }
    }

    public void UseNextListOnEnd()
    {
        if (CurrentListData.IsLastString())
        {
            IncrementListNum();
        }
    }
}