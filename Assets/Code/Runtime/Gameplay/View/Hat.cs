using Code.Runtime.Data;
using Code.Runtime.Infrastructure.Services.StaticData;
using Code.Runtime.StaticData;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Gameplay.View
{
    public  class Hat : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        private IStaticDataService _staticDataService;

        [Inject]
        private void Construct(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        private void OnValidate()
        {
            _spriteRenderer ??= GetComponent<SpriteRenderer>();
        }
        
        public void SetHat(HatTypeId hatTypeId)
        {
            if (hatTypeId == HatTypeId.None)
            {
                _spriteRenderer.enabled = false;
                return;
            }
            
            HatConfig config = _staticDataService.GetHatConfig(hatTypeId);
            _spriteRenderer.sprite = config.Sprite;
        }
    }
    
}