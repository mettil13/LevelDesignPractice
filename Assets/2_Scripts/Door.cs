using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private MeshRenderer _mesh;
    private Collider _collider;
    private ButtonObject _linkedButton;
    private void Awake()
    {
        _mesh = GetComponent<MeshRenderer>();
        _collider = GetComponent<Collider>();

        _linkedButton = GetComponentInChildren<ButtonObject>();
        if (_linkedButton)
        {
            _linkedButton.OnToggle += ToggleDoor;
        }
    }
    private void OnDestroy()
    {
        if (_linkedButton)
        {
            _linkedButton.OnToggle -= ToggleDoor;
        }
    }
    public void ToggleDoor(bool active)
    {
        _mesh.enabled = !active;
        _collider.enabled = !active;
    }
}
