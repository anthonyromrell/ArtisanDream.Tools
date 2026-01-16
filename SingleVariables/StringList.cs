using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

// Attribute allows to create instances of this class within Unity's asset creation menu
[CreateAssetMenu(menuName = "ScriptableObjects/StringList")]
public class StringList : ScriptableObject
{
    public List<string> stringListObj;
    public string currentString;
    public UnityEvent onLineNumberChanged;

    [SerializeField] private int currentLineNumber;

    public int CurrentLineNumber
    {
        get => currentLineNumber;
        private set
        {
            currentLineNumber = Mathf.Clamp(value, 0, stringListObj.Count - 1);
            onLineNumberChanged?.Invoke();
        }
    }

    // Constructors...

    public void NextString()
    {
        if (!IsNotEmpty()) return;
        currentString = stringListObj[CurrentLineNumber];
        CurrentLineNumber = (CurrentLineNumber + 1) % stringListObj.Count;
    }

    public bool IsLastString()
    {
        return CurrentLineNumber == stringListObj.Count - 1;
    }
    
    public void SetCurrentStringIfValid(int num)
    {
        if (!IsNotEmpty()) return;
        if (IsValidLength(num))
        {
            currentString = stringListObj[CurrentLineNumber];
        }
    }

    public void CheckNum(int num)
    {
        if (IsValidLength(num)) return;
        IncrementLineNumber();
    }
    
    public void CheckNum(IntData obj)
    {
        if (IsValidLength(obj.Value)) return;
        IncrementLineNumber();
    }

    public void ResetToZero() => CurrentLineNumber = 0;

    public void IncrementLineNumber() => CurrentLineNumber = (CurrentLineNumber + 1) % stringListObj.Count;

    public void DecrementLineNumber() =>
        CurrentLineNumber = (CurrentLineNumber - 1 + stringListObj.Count) % stringListObj.Count;

    public bool IsNotEmpty() => stringListObj.Any();

    private bool IsValidLength(int num) => num < stringListObj[CurrentLineNumber].Length && num >= 0;
}