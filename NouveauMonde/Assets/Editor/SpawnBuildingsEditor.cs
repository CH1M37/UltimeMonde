using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SpawnOnSphere))]
public class SpawnBuildingsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        SpawnOnSphere spawner = (SpawnOnSphere)target;

        if (GUILayout.Button("Spawn Buildings"))
        {
            spawner.SpawnBuildings();
        }
    }
}
