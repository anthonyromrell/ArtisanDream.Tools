using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Attribute allows to create instances of this class within Unity's asset creation menu
[CreateAssetMenu(menuName = "ScriptableObjects/StringList")]
public class StringList : ScriptableObject
{
    // A list of strings, can be manipulated and populated in Unity's editor
    public List<string> stringListObj;

    // A UnityEvent invoked whenever the current line number changes
    public UnityEvent onLineNumberChanged;

    // A private variable that keeps track of the current line renumber
    // represented in the stringListObj
    [SerializeField] private int currentLineNumber;

    // Property allows getting and setting the line number
    // The setter clamps its value to prevent it from going out of bounds
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
    
    public void CheckNum (IntData num)
    {
        if (num.Value < stringListObj[currentLineNumber].Length && num.Value >= 0)
            return;
        
        IncrementLineNumber();
    }
    
    public void CheckNum (int num)
    {
        Debug.Log(num);
        if (num < stringListObj[currentLineNumber].Length && num >= 0)
            return;
        
        IncrementLineNumber();
    }

    // Returns the string at the current line number or null if the list is empty or doesn't exist
    public string CurrentLine => stringListObj != null && CurrentLineNumber < stringListObj.Count
        ? stringListObj[CurrentLineNumber]
        : null;

    // Resets the line number to the first line (0)
    public void ResetToZero()
    {
        CurrentLineNumber = 0;
    }

    // Increments the line number by one, wraps around to 0 if end of list is reached
    public void IncrementLineNumber()
    {
        if (IsNotEmpty())
        {
            CurrentLineNumber = (CurrentLineNumber + 1) % stringListObj.Count;
        }
    }

    // Decrements the line number by one, wraps around to the end of the list if start is reached
    public void DecrementLineNumber()
    {
        if (IsNotEmpty())
        {
            CurrentLineNumber = (CurrentLineNumber - 1 + stringListObj.Count) % stringListObj.Count;
        }
    }

    // Helper method that checks whether the list is not null and has items
    public bool IsNotEmpty()
    {
        return stringListObj is { Count: > 0 };
    }
}