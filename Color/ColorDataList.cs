using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class ColorDataList : ScriptableObject
{
    public List<ColorData> colorList;
    public UnityEvent onLineNumberChanged;

    [SerializeField] private int currentLineNumber;

    public int CurrentLineNumber
    {
        get => currentLineNumber;
        private set
        {
            if (colorList is not { Count: > 0 }) return;
            currentLineNumber = Mathf.Clamp(value, 0, colorList.Count - 1);
            onLineNumberChanged?.Invoke();
        }
    }


    public ColorData CurrentColor => colorList != null && CurrentLineNumber < colorList.Count
        ? colorList[CurrentLineNumber]
        : null;

    public void ResetToZero()
    {
        CurrentLineNumber = 0;
    }

    public void IncrementLineNumber()
    {
        if (IsNotEmpty())
        {
            CurrentLineNumber = (CurrentLineNumber + 1) % colorList.Count;
        }
    }

    public void DecrementLineNumber()
    {
        if (IsNotEmpty())
        {
            CurrentLineNumber = (CurrentLineNumber - 1 + colorList.Count) % colorList.Count;
        }
    }

    public bool IsNotEmpty()
    {
        return colorList is { Count: > 0 };
    }

    public void CheckNum(IntData colorNumber)
    {
        throw new System.NotImplementedException();
    }
}