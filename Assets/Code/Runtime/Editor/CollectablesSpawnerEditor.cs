using System.Numerics;
using Code.Runtime.Extensions;
using Code.Runtime.Gameplay.Logic;
using UnityEditor;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Code.Runtime.Editor
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
            Handles.DrawLine(position.SetX(-spawner.RandomDeltaX), position.SetX(spawner.RandomDeltaX), RandomXRangeThickness);
        }
    }
}