using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create StageDatabase")]
public class StageDatabase : ScriptableObject
{
    public Stage[] stageList;
}

[System.Serializable]
public class Stage
{
    public Sprite stageImage;
    public bool warpEvent;
}
