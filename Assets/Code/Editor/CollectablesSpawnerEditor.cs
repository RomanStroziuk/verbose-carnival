using UnityEditor;
using UnityEngine;
using Code.Runtime.Gameplay.Logic.Collectables;
using Code.Runtime.StaticData;

namespace Code.Editor
{
    [CustomEditor(typeof(CollectablesSpawner))]
    public class CollectablesSpawnerEditor : UnityEditor.Editor
    {
        private const float RandomXRangeThickness = 3;

        [DrawGizmo(GizmoType.Selected | GizmoType.Active | GizmoType.NonSelected)]
        public static void RenderCustomGizmo(CollectablesSpawner spawner, GizmoType gizmo)
        {
            if (spawner == null) return;
            if (!Application.isPlaying)
            {
                var config = Resources.Load<CollectablesConfig>("Configs/CollectablesConfig");
                if (config == null) return;
            }

            Handles.color = Color.yellow;

            Vector3 position = spawner.transform.position;
            float randomDeltaX = 0f;

            try
            {
                randomDeltaX = spawner.RandomDeltaX;
            }
            catch
            {
                return;
            }

            Handles.DrawLine(position + Vector3.right * -randomDeltaX, position + Vector3.right * randomDeltaX, RandomXRangeThickness);
        }
    }
}