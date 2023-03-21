using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

    public class LoginSceneUI : BaseUI
    {
        [SerializeField] private Button sandBoxButton;
        [SerializeField] private Button QuestButton;
        [SerializeField] private GameObject canvas;
        public void Awake()
        {
            base.Awake();
            sandBoxButton.onClick.AddListener(sandBoxModeAccept);
            QuestButton.onClick.AddListener(questModeAccept);
        }

        private void sandBoxModeAccept()
        {
            Constants.modeID = 1;
            canvas.gameObject.SetActive(false);
            SceneManager.LoadScene(Constants.SCENE.CHARACTER_SELECTION, LoadSceneMode.Additive);
        }
        private void questModeAccept()
        {
            Constants.modeID = 2;
            canvas.gameObject.SetActive(false);
            SceneManager.LoadScene(Constants.SCENE.CHARACTER_SELECTION, LoadSceneMode.Additive);
        }
    }
