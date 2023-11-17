using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StringListManager : ScriptableObject
{
    public List<StringList> stringListDatas;
    public int currentListNum;

    private StringList ReturnCurrentData()
    {
        return stringListDatas[currentListNum];
    }

    private void IncrementListNum()
    {
        if (currentListNum < stringListDatas.Count - 1)
        {
            currentListNum++;
        }
        else
        {
            currentListNum = 0;
        }
    }

    public void UseNextListOnEnd()
    {
        if (ReturnCurrentData().CurrentLineNumber == ReturnCurrentData().stringListObj.Count - 1 )
        {
            IncrementListNum();
        }
    }
}
