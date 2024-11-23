using UnityEngine;

namespace Code.Runtime.Gameplay.Logic
{
    public sealed class Collector : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.TryGetComponent(out ICollecteble collecteble))
            return;
            
            if (collecteble.IsCollected)
            return;

          
            collecteble.Collect(this);
        }

        
    }
}