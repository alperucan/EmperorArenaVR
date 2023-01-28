using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string currentSceneName;
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }
    private void Start()
    {
            
        SceneManager.LoadScene(Constants.SCENE.CHARACTER_SELECTION, LoadSceneMode.Additive);
    }
    private void OnSceneUnloaded(Scene scene)
    {
        switch (scene.name)
        {
            case Constants.SCENE.CHARACTER_SELECTION:
                UIManager.Instance.Hide();
                break;
            default:
                    
                break;
        }
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        switch (scene.name)
        {
            case Constants.SCENE.CHARACTER_SELECTION:
                UIManager.Instance.Show(Constants.UI.CHARACTER_SELECTION);
                break;
            default:
                    
                break;
        }
    }
}