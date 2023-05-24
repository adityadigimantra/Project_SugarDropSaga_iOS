using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


#if UNITY_EDITOR
[CustomEditor(typeof(LevelPrefab))]
public class LevelPrefabEditor : Editor {
    public override void OnInspectorGUI() {
        DrawDefaultInspector(); // for other non-HideInInspector fields

        LevelPrefab level = (LevelPrefab)target;

        level.gameType = (GameManager.GameType)EditorGUILayout.EnumPopup("Game Type", level.gameType);

        switch (level.gameType) {
            case GameManager.GameType.CollectTarget:
                level.targetCount = EditorGUILayout.IntSlider("Number of Targets", level.targetCount, 1, 3);

                for (int i = 0; i < level.targetCount; i++) {
                    level.targetNums[i] = EditorGUILayout.IntField("Number to Collect" + (i + 1), level.targetNums[i]);
                }
                break;

            case GameManager.GameType.Score:
                level.scoreToReach = EditorGUILayout.IntField("Score To Reach", level.scoreToReach);
                break;

            case GameManager.GameType.Escape:
                level.targetCount = EditorGUILayout.IntSlider("Number of Targets", level.targetCount, 1, 3);

                for (int i = 0; i < level.targetCount; i++) {
                    level.targetNums[i] = EditorGUILayout.IntField("Number to Collect" + (i + 1), level.targetNums[i]);
                }
                level.percentToSpawnAnimal = EditorGUILayout.IntField("Percent To Spawn Target Animal", level.percentToSpawnAnimal);
                break;
        }
    }
}
#endif