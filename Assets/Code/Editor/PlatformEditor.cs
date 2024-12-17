using Code.Runtime.Extensions;
using Code.Runtime.Gameplay.Logic;
using Code.Runtime.Gameplay.Logic.Platform;
using UnityEditor;
using UnityEngine;

namespace Code.Editor
{
    [CustomEditor(typeof(PlatformMovement))]
    public class PlatformEditor : UnityEditor.Editor
    {
        private const float LineThickness = 3f;

        private void OnSceneGUI()
        {
            var platform = (PlatformMovement)target;

            Handles.color = Color.green;
            Handles.DrawLine(platform.pointA, platform.pointB, LineThickness);

            Handles.color = Color.red;
            EditorGUI.BeginChangeCheck();

            Vector3 newPointA = Handles.PositionHandle(platform.pointA, Quaternion.identity);
            Vector3 newPointB = Handles.PositionHandle(platform.pointB, Quaternion.identity);

            newPointA = newPointA.SetX(Mathf.Clamp(newPointA.x, -10, 10));
            newPointB = newPointB.SetX(Mathf.Clamp(newPointB.x, -10, 10));

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(platform, "Move Points");
                platform.pointA = newPointA;
                platform.pointB = newPointB;

                EditorUtility.SetDirty(platform);
            }

            Handles.color = Color.yellow;
            Handles.DrawLine(platform.transform.position, platform.pointA, LineThickness);
            Handles.DrawLine(platform.transform.position, platform.pointB, LineThickness);
        }

        private void OnDrawGizmosSelected()
        {
            var platform = (PlatformMovement)target;

            Gizmos.color = Color.green;
            Gizmos.DrawLine(platform.pointA, platform.pointB);

            Gizmos.color = Color.red;
            Gizmos.DrawSphere(platform.pointA, 0.2f);
            Gizmos.DrawSphere(platform.pointB, 0.2f);
        }
    }
}