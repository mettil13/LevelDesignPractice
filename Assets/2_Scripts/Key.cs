using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public int Value;
    [SerializeField] private InventorySO _inventory;

    private void OnTriggerEnter(Collider other)
    {
        _inventory.AddKey(Value);
        Destroy(gameObject);
    }
}
