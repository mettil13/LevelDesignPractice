using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class InventorySO : ScriptableObject
{
    public int OwnedNumber;
    public UnityAction OnNumberChange;
    private void OnEnable()
    {
        OwnedNumber = 0;
    }
    public void Add(int value)
    {
        OwnedNumber += value;
        OnNumberChange?.Invoke();
    }
    public int Pay(int value)
    {
        int paidValue = 0;
        if (OwnedNumber > value)
        {
            paidValue = value;
            Add(-value);
        }
        else
        {
            paidValue = OwnedNumber;
            Add(-OwnedNumber);
        }

        return paidValue;
    }
}
