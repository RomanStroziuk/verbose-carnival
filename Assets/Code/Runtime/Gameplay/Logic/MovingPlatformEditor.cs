using UnityEditor;
using UnityEngine;

namespace Code.Runtime.Gameplay.Logic
{
    [CustomEditor(typeof(MovingPlatform))]
    public class MovingPlatformEditor : Editor
    {
        private void OnSceneGUI()
        {
            var platform = (MovingPlatform)target;

            Handles.color = Color.green;
            Handles.DrawLine(platform.pointA, platform.pointB);

            Handles.color = Color.red;
            EditorGUI.BeginChangeCheck();

            Vector3 newPointA = Handles.PositionHandle(platform.pointA, Quaternion.identity);
            Vector3 newPointB = Handles.PositionHandle(platform.pointB, Quaternion.identity);

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(platform, "Move Points");
                platform.pointA = newPointA;
                platform.pointB = newPointB;
                EditorUtility.SetDirty(platform);
            }
        }
    }
}