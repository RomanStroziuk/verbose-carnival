using Code.Runtime.Gameplay.Logic.Movement;
using Code.Runtime.Gameplay.View.UI;
using DG.Tweening;
using UnityEngine;

namespace Code.Runtime.Infrastructure.Services.CleaningService
{
    public class CleaningService : ICleaningService
    {
        public void CleanLevel()
        {
            CleanObjectsOfType<PlayerInputX>();
            CleanObjectsOfType<Hud>();
            DOTween.KillAll();
        }
        
        private void CleanObjectsOfType<T>() where T : Component
        {
            var components = Object.FindObjectsOfType<T>();
            
            foreach (T component in components)
            {
                Object.Destroy(component.gameObject);
            }
        }
    }
}