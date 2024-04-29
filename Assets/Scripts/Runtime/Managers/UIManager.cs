using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        CoreGameSignals.Instance.onLevelInitialize += OnLevelInitialize;
        CoreGameSignals.Instance.onLevelSuccessful += OnLevelSuccessful;
        CoreGameSignals.Instance.onLevelFailed += OnLevelFailed;
        CoreGameSignals.Instance.onReset += OnReset;
    }

    private void OnReset()
    {
        CoreUISignals.Instance.onCloseAllPanels?.Invoke();
        CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelType.Start, 1);
    }

    private void OnLevelInitialize(byte arg0)
    {
        CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelType.Level, 0);
        UISignals.Instance.onSetLevelValue?.Invoke((byte)CoreGameSignals.Instance.onGetLevelValue?.Invoke());
    }
    
    private void OnLevelSuccessful()
    {
        CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelType.Win, 2);
    }
    
    private void OnLevelFailed()
    {
        CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelType.Fail, 2);

    }

    private void UnSubscribeEvents()
    {
        CoreGameSignals.Instance.onLevelInitialize -= OnLevelInitialize;
        CoreGameSignals.Instance.onLevelSuccessful -= OnLevelSuccessful;
        CoreGameSignals.Instance.onLevelFailed -= OnLevelFailed;
        CoreGameSignals.Instance.onReset -= OnReset;
    }

    private void OnDisable()
    {
        UnSubscribeEvents();
    }

    public void Play()
    {
        Debug.Log("Executed Play Button.");
        UISignals.Instance.onPlay?.Invoke();
        CoreUISignals.Instance.onClosePanel?.Invoke(1);
        InputSignals.Instance.onEnableInput?.Invoke();
    }

    public void NextLevel()
    {
        CoreGameSignals.Instance.onNextLevel?.Invoke();
    }

    public void RestartLevel()
    {
        CoreGameSignals.Instance.onRestartLevel?.Invoke();
    }
}
