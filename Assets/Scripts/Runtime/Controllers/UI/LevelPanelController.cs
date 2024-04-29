using DG.Tweening;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelPanelController : MonoBehaviour
{
    #region Self Variables

    #region Serialized Variables

    [SerializeField] List<Image> stageImages = new List<Image>();
    [SerializeField] private List<TextMeshProUGUI> levelTexts = new List<TextMeshProUGUI>();

    #endregion


    #endregion

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        UISignals.Instance.onSetLevelValue += OnSetLevelValue;
        UISignals.Instance.onSetStageColor += OnSetStageColor;
    }

    private void OnSetStageColor(byte stageValue)
    {
        stageImages[stageValue].DOColor(new Color(0.7745547f, 0.4745098f,1), 0.5f);
    }

    private void OnSetLevelValue(byte levelValue)
    {
        var additionalValue = ++levelValue;
        levelTexts[0].text = additionalValue.ToString();
        additionalValue++;
        levelTexts[1].text = additionalValue.ToString();
    }

    private void UnSubscribeEvents()
    {
        UISignals.Instance.onSetLevelValue -= OnSetLevelValue;
        UISignals.Instance.onSetStageColor -= OnSetStageColor;
    }

    private void OnDisable()
    {
        UnSubscribeEvents();
    }
}
