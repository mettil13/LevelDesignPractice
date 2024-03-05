using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockPower : MonoBehaviour
{
    public PowerType UnlockedPower;
    private ButtonObject _linkedButton;
    private CharacterController3D _characterController;
    private void Awake()
    {
        _linkedButton = GetComponentInChildren<ButtonObject>();
        _characterController = FindObjectOfType<CharacterController3D>();
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
        if (active)
        {
            if (UnlockedPower == PowerType.Push)
            {
                _characterController.PushUnlocked = true;
            }
            else
            {
                _characterController.PullUnlocked = true;
            }
        }
    }
}
public enum PowerType
{
    Push,
    Pull
}
