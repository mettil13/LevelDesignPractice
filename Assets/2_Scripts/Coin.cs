using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int Value;
    [SerializeField] private InventorySO _inventory;

    private void OnTriggerEnter(Collider other)
    {
        _inventory.Add(Value);
        Destroy(gameObject);
    }
}
