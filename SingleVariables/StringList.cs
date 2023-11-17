using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StringList : ScriptableObject
{
    public List<string> stringListObj;
    [SerializeField] private int currentLineNumber;

    public int CurrentLineNumber
    {
        get => currentLineNumber;
        private set
        {
            if (stringListObj is { Count: > 0 })
                currentLineNumber = Mathf.Clamp(value, 0, stringListObj.Count - 1);
        }
    }

    public string ReturnCurrentLine()
    {
        if (stringListObj != null && CurrentLineNumber < stringListObj.Count)
        {
            return stringListObj[CurrentLineNumber];
        }
        return null; // or handle appropriately if the list is empty or index out of range
    }

    public void ResetToZero()
    {
        currentLineNumber = 0;
    }

    public void IncrementLineNumber()
    {
        if (stringListObj == null || stringListObj.Count == 0) return;
        currentLineNumber = (currentLineNumber + 1) % stringListObj.Count;
    }

    // Optional: Additional utility methods
    public void DecrementLineNumber()
    {
        if (stringListObj == null || stringListObj.Count == 0) return;
        currentLineNumber = (currentLineNumber - 1 + stringListObj.Count) % stringListObj.Count;
    }

    public bool IsEmpty()
    {
        return stringListObj == null || stringListObj.Count == 0;
    }
}