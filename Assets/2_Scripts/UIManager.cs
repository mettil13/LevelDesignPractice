using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private InventorySO _inventory;
    [SerializeField] private TextMeshProUGUI _coinNumber;
    [SerializeField] private TextMeshProUGUI _keyNumber;
    [SerializeField] private TextMeshProUGUI _infoText;
    [SerializeField] private GameObject _infoBox;

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
        _coinNumber.text = _inventory.NumberOfCoins.ToString();
        _keyNumber.text = _inventory.NumberOfKeys.ToString();
    }
    public void ShowText(bool b, string textToShow)
    {
        _infoText.text = textToShow;
        _infoBox.SetActive(b);
    }
}
