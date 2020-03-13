using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StringList : ScriptableObject
{
    public List<string> stringListObj;
    public int currentLineNumber;

    public string ReturnCurrentLine()
    {
        return stringListObj[currentLineNumber];
    }

    public void ResetToZero()
    {
        currentLineNumber = 0;
    }
    
    
    public void IncrementLineNumber()
    {
        if (currentLineNumber < stringListObj.Count-1)
        {
            currentLineNumber++;
        }
        else
        {
            currentLineNumber = 0;
        }
    }
}