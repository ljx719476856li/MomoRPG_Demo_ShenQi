using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class UIVIew : View
{
    /// <summary>
    /// 进行UI的各种初始化
    /// </summary>
    /// 

    private bool isCharacterShow = false;

    [SerializeField]
    private CanvasGroup characterPanel;

    protected override void Awake()
    {
        base.Awake();
        characterPanel = GameObject.Find("CharacterPanel").GetComponent<CanvasGroup>();
        characterPanel.alpha = 0;
    }

    public void Init()
    {
        Debug.Log("UIView Init complete");
    }

    public void Show()
    {
        if (isCharacterShow == false)
        {
            characterPanel.alpha = 1;
            isCharacterShow = true;
        }
        else
        {
            characterPanel.alpha = 0;
            isCharacterShow = false;
        }

    }

    public void Hide()
    {

    }
}
