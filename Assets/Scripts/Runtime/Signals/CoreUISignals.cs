using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoreUISignals : MonoBehaviour
{
    #region Singleton
    
    public static CoreUISignals Instance;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(Instance);
            return;
        }

        Instance = this;
    }

    #endregion

    public UnityAction<UIPanelType, int> onOpenPanel = delegate { };
    public UnityAction<int> onClosePanel = delegate { };
    public UnityAction onCloseAllPanels = delegate { };
}
