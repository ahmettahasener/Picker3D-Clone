using com.cyborgAssets.inspectorButtonPro;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region Self Variables

    #region Serialized Variables

    [SerializeField] private Transform levelHolder;
    [SerializeField] private byte totalLevelCount;

    #endregion

    #region Private Variables

    private OnLevelLoaderCommand _levelLoaderCommand;
    private OnLevelDestroyerCommand _levelDestroyerCommand;

    private byte _currentLevel;
    private LevelData _levelData;

    #endregion

    #endregion

    private void Awake()
    {
        //_levelData = GetLevelData();
        //_currentLevel = GetActiveLevel();

        Init();
    }

    private void Init()
    {
        _levelLoaderCommand = new OnLevelLoaderCommand(levelHolder);
        _levelDestroyerCommand = new OnLevelDestroyerCommand(levelHolder);
    }

    private LevelData GetLevelData()
    {
        return Resources.Load<CD_Levels>("Data/CD_Level").levels[_currentLevel];
    }

    private byte GetActiveLevel()
    {
        return _currentLevel;
    }


}
