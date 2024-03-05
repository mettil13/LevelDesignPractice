using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGroupToggle : MonoBehaviour
{
    public List<GameObject> GameObjectsToToggle;
    private ButtonObject _linkedButton;
    private List<bool> _objectsStartingStates = new List<bool>();
    private void Awake()
    {
        _linkedButton = GetComponentInChildren<ButtonObject>();
        foreach (var item in GameObjectsToToggle)
        {
            _objectsStartingStates.Add(item.activeSelf);
        }
        if (_linkedButton)
        {
            _linkedButton.OnToggle += ToggleObjects;
        }
    }
    private void OnDestroy()
    {
        if (_linkedButton)
        {
            _linkedButton.OnToggle -= ToggleObjects;
        }
    }
    public void ToggleObjects(bool active)
    {
        for (int i = 0; i < GameObjectsToToggle.Count; i++)
        {
            bool newState;
            newState = active ? !_objectsStartingStates[i] : _objectsStartingStates[i];
            GameObjectsToToggle[i].SetActive(newState);
        }
    }
}
