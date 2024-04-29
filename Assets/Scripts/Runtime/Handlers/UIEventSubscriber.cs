using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEventSubscriber : MonoBehaviour
{
    #region Self Variables

    #region Serialized Variables

    [SerializeField] private UIEventSubscriptionTypes type;
    [SerializeField] private Button button;

    #endregion

    #region Private Variables

    private UIManager _manager;

    #endregion

    #endregion

    private void Awake()
    {
        GetReferences();
    }

    private void GetReferences()
    {
        _manager = FindObjectOfType<UIManager>();

    }

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        switch (type)
        {
            case UIEventSubscriptionTypes.OnPlay:
                button.onClick.AddListener(_manager.Play);
                break;
            case UIEventSubscriptionTypes.OnNextLevel:
                button.onClick.AddListener(_manager.NextLevel);
                break;
            case UIEventSubscriptionTypes.OnRestartLevel:
                button.onClick.AddListener(_manager.RestartLevel);
                break;
            default:
                break;
        }
    }

    private void UnSubscribeEvents()
    {
        switch (type)
        {
            case UIEventSubscriptionTypes.OnPlay:
                button.onClick.RemoveListener(_manager.Play);
                break;
            case UIEventSubscriptionTypes.OnNextLevel:
                button.onClick.RemoveListener(_manager.NextLevel);
                break;
            case UIEventSubscriptionTypes.OnRestartLevel:
                button.onClick.RemoveListener(_manager.RestartLevel);
                break;
            default:
                break;
        }
    }

    private void OnDisable()
    {
        UnSubscribeEvents();
    }
}