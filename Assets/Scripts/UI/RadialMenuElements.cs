using System;
using UnityEngine;
using UnityEngine.UI;

    public class RadialMenuElements : MonoBehaviour
    {
        [SerializeField] private string ui;

        private void Awake()
        {
            var button = GetComponent<Button>();
            button.onClick.AddListener(delegate { UIManager.Instance.Show(ui); });
        }
    }
