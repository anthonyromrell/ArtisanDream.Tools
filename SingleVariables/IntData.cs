using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;

[CreateAssetMenu(menuName = "Single Variables/IntData")]
public class IntData : ScriptableObject
{
<<<<<<< HEAD
    [SerializeField] private int value, minValue, maxValue;
    public int Value 
    {
        get => value;
        set
        {
            this.value = value;
            InvokeValueChangedEvent();
        }
=======
    [SerializeField] private int value;
    private int currentValue;
    public UnityEvent decrementEvent, valueChangeEvent,atZeroEvent, compareTrueEvent;

    public int Value
    {
        get => value;
        set => this.value = value;
    }

    public void SetValue(int amount)
    {
        Value = amount;
        valueChangeEvent.Invoke();
>>>>>>> origin/GameActionRefactor
    }
    private int currentValue;
    public UnityEvent decrementEvent, atZeroEvent, minValueEvent, enableEvent, maxValueEvent, valueChangeEvent;

    private void OnEnable()
    {
        enableEvent?.Invoke();
    }

    private void InvokeValueChangedEvent()
    {
        valueChangeEvent?.Invoke();
    }

    public void UpdateFromCurrentValue()
    {
        Value = currentValue;
<<<<<<< HEAD
=======
        valueChangeEvent.Invoke();
>>>>>>> origin/GameActionRefactor
    }

    public void UpdateCurrentValue()
    {
        currentValue = Value;
<<<<<<< HEAD
=======
        valueChangeEvent.Invoke();
>>>>>>> origin/GameActionRefactor
    }

    public void UpdateValue(int amount)
    {
        Value += amount;
<<<<<<< HEAD
    }

    public void IncrementValue()
    {
        Value++;
    }

    public void DecrementToZero()
    {
        if (Value > 0)
        {
            Value--;
            decrementEvent?.Invoke();
        }
        CheckZero();
    }

    private void CheckZero()
    {
        if (Value == 0)
        {
            atZeroEvent?.Invoke();
        }
    }

    public void UpdateValue(Object data)
    {
        if (data is IntData newData)
        {
            Value += newData.Value;
        }
=======
        valueChangeEvent.Invoke();
    }

    public void UpdateValue(Object data)
    {
        var newData = data as IntData;
        if (newData != null) Value += newData.Value;
        valueChangeEvent.Invoke();
    }
    
    public void UpdateValueZeroCheck(int num)
    {
        UpdateValue(num);
        ZeroCheck();
    }

    public void ZeroCheck()
    {
        if (Value <= 0)
        {
            value = 0;
        }
    }

    public void IncrementValue()
    {
        Value++;
        valueChangeEvent.Invoke();
    }

    public void DecrementToZero()
    {
        if (Value > 0)
        {
            Value--;
            decrementEvent.Invoke();
        }
        if (Value == 0){
            atZeroEvent.Invoke();
        }
    }

    
    
    public void SetValue(Object data)
    {
        var newData = data as IntData;
        if (newData == null) return;
        Value = newData.Value;
        valueChangeEvent.Invoke();
>>>>>>> origin/GameActionRefactor
    }

    public void SetValue(Object data)
    {
<<<<<<< HEAD
        if (data is IntData newData)
=======
        if (Value == data.Value)
>>>>>>> origin/GameActionRefactor
        {
            Value = newData.Value;
        }
    }
    
    public void CheckValueRange()
    {
<<<<<<< HEAD
        CheckValueRange(minValue, maxValue);
    }
    
    private void CheckValueRange(int minValue, int maxValue)
    {
        if (Value < minValue)
=======
        if (Value == data)
>>>>>>> origin/GameActionRefactor
        {
            minValueEvent.Invoke();
            Value = minValue;
        }
        else if (Value > maxValue)
        {
            maxValueEvent.Invoke();
            Value = maxValue;
        }
    }
}