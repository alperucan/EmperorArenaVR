using System;
using UnityEngine;

    public class LevelManager : MonoBehaviour
    {
        private void Start()
        {
            UIManager.Instance.characterSelectionUI.Show();
        }
    }
