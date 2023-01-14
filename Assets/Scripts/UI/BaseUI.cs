using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUI : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    protected void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Show() 
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;
        EventManager.Instance.ShowUI();

    }

    public void Hide() 
    {
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
        EventManager.Instance.HideUI();
    }

}
