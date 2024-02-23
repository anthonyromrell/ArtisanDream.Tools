using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class StringList : ScriptableObject
{
    public List<string> stringListObj;

    [SerializeField] private int currentLineNumber;

    public UnityEvent onLineNumberChanged;

    public int CurrentLineNumber
    {
        get => currentLineNumber;
        private set
        {
            if (stringListObj is not { Count: > 0 }) return;
            currentLineNumber = Mathf.Clamp(value, 0, stringListObj.Count - 1);
            onLineNumberChanged?.Invoke();
        }
    }

    public string CurrentLine => stringListObj != null && CurrentLineNumber < stringListObj.Count
        ? stringListObj[CurrentLineNumber]
        : null;

    public void ResetToZero()
    {
        CurrentLineNumber = 0;
    }

    public void IncrementLineNumber()
    {
        if (IsNotEmpty())
        {
            CurrentLineNumber = (CurrentLineNumber + 1) % stringListObj.Count;
        }
    }
    
    public void DecrementLineNumber()
    {
        if (IsNotEmpty())
        {
            CurrentLineNumber = (CurrentLineNumber - 1 + stringListObj.Count) % stringListObj.Count;
        }
    }

    public bool IsNotEmpty()
    {
        return stringListObj is { Count: > 0 };
    }
}