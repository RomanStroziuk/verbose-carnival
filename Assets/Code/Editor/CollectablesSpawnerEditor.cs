using UnityEditor;
using UnityEngine;
using Code.Runtime.Gameplay.Logic;

namespace Code.Editor
{
    [CustomEditor(typeof(CollectablesSpawner))]
    public class CollectablesSpawnerEditor : UnityEditor.Editor
    {
        private const float RandomXRangeThickness = 3;

        [DrawGizmo(GizmoType.Selected | GizmoType.Active | GizmoType.NonSelected)]
        public static void RenderCustomGizmo(CollectablesSpawner spawner, GizmoType gizmo)
        {
            Handles.color = Color.yellow;

            Vector3 position = spawner.transform.position;
            Handles.DrawLine(position + Vector3.right * -spawner.RandomDeltaX,
            position + Vector3.right * spawner.RandomDeltaX,
            RandomXRangeThickness);
        }
    }
}