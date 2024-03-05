using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ButtonObject : MonoBehaviour
{
    public ButtonType Type;
    public bool IsOn;
    public Material MaterialWhenOn;
    public Material MaterialWhenOff;
    public UnityAction<bool> OnToggle;

    [Header("Timed")]
    public float TimeItStaysOn;

    [Header("Paid")]
    public int KeyCost;
    public InventorySO Inventory;
    public TextMeshPro CostText;
    private MeshRenderer _mesh;
    private List<GameObject> _objectsOnButton = new List<GameObject>();

    private void Awake()
    {
        _mesh = GetComponent<MeshRenderer>();
        UpdateMaterial();


        if (Type == ButtonType.Timed && IsOn)
        {
            StartCoroutine(TimerCoroutine());
        }
        if (Type == ButtonType.Paid)
        {
            UpdateCostText();
        }
    }
    public void Activate(bool b)
    {
        IsOn = b;
        UpdateMaterial();
        OnToggle?.Invoke(IsOn);
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (Type)
        {
            case ButtonType.SingleUse:
                Activate(true);
                break;
            case ButtonType.Timed:
                StopAllCoroutines();
                StartCoroutine(TimerCoroutine());
                break;
            case ButtonType.Toggle:
                _objectsOnButton.Add(other.gameObject);
                Activate(true);
                break;
            case ButtonType.Paid:
                if (other.TryGetComponent(out CharacterController3D character))
                {
                    KeyCost -= Inventory.PayKey(KeyCost);
                    UpdateCostText();
                    if (KeyCost == 0)
                    {
                        Activate(true);
                    }
                }
                break;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (Type == ButtonType.Toggle)
        {
            _objectsOnButton.Remove(other.gameObject);
            if (_objectsOnButton.Count == 0)
            {
                Activate(false);
            }
        }
    }
    private IEnumerator TimerCoroutine()
    {
        Activate(true);
        yield return new WaitForSeconds(TimeItStaysOn);
        Activate(false);
    }
    private void UpdateMaterial()
    {
        if (IsOn)
        {
            _mesh.material = MaterialWhenOn;
        }
        else
        {
            _mesh.material = MaterialWhenOff;
        }
    }
    private void UpdateCostText()
    {
        CostText.text = KeyCost.ToString();
    }
}

public enum ButtonType
{
    SingleUse,
    Timed,
    Toggle,
    Paid
}
