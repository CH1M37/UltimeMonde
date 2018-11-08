using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Orient))]
public class OrientBuildingsEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Orient orient = (Orient)target;

        if (GUILayout.Button("Orient Buildings"))
        {
            orient.OrientBuildings();
        }
    }
}
