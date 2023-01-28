using System;
using UnityEngine;
using UnityEngine.UI;

public class Menu : BaseUI
{
    [SerializeField] private Button closeButton;
    [SerializeField] private Button saveButton;
    [SerializeField] private Button loadButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button optionsButton;


    private void Awake()
    {
        base.Awake();
        closeButton.onClick.AddListener(UIManager.Instance.Hide);
    }
}
