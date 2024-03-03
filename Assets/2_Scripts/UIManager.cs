using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private InventorySO _inventory;
    [SerializeField] private TextMeshProUGUI _itemNumber;

    private void Awake()
    {
        _inventory.OnNumberChange += UpdateText;
        UpdateText();
    }
    private void OnDestroy()
    {
        _inventory.OnNumberChange -= UpdateText;
    }
    private void UpdateText()
    {
        _itemNumber.text = _inventory.OwnedNumber.ToString();
    }
}
