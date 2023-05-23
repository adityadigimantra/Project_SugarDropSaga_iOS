using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Contains data about the level - Editor: LevelPrefabEditor.cs
/// </summary>
public class LevelPrefab : MonoBehaviour
{

    public static LevelPrefab _instance;

    public int allMoves;

    [HideInInspector]
    public GameManager.GameType gameType;

    [HideInInspector]
    public int scoreToReach; // GameType.Score


    public int[] targetNums;
    
    public int targetCount;
    [HideInInspector]
    public int percentToSpawnAnimal;

    GameManager gm;

    // Start is called before the first frame update
    void Start() 
    {
        gm = GameManager._instance;

        SetUpLevel();
    }

    // Update is called once per frame
    void Update() {

    }

    void SetUpLevel()
    {
        gm.SetLevel(this);
    }
}

