using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CD_Level",menuName = "Picker3D/CD_Level",order = 0)]
public class CD_Levels : ScriptableObject
{
    public List<LevelData> levels;
}
