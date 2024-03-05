using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowText : MonoBehaviour
{
    [TextArea(5, 20)]
    public string TextToShow;
    private UIManager _uiManager;
    private void Awake()
    {
        _uiManager = FindObjectOfType<UIManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        _uiManager.ShowText(true, TextToShow);
    }
    private void OnTriggerExit(Collider other)
    {
        _uiManager.ShowText(false, TextToShow);
    }
}
