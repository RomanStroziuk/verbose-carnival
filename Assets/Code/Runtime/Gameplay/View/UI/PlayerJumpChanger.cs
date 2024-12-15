using Code.Runtime.Data;
using Code.Runtime.Infrastructure.Services.PlayerInventory;
using Code.Runtime.Infrastructure.Services.StaticData;
using Code.Runtime.StaticData;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Runtime.Gameplay.View.UI
{
    public class PlayerJumpChanger : MonoBehaviour
    {
        [SerializeField] private Button _button;

        [SerializeField] private Image _jumpimage;

        private IPlayerInventoryService _inventoryService;
        private IStaticDataService _staticDataService;

        [Inject]
        private void Construct(IPlayerInventoryService inventoryService, IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            _inventoryService = inventoryService;
        }

        private void Awake() =>
            _button.onClick.AddListener(ChangeJump);

        private void Start()
        {
            UpdateView();
        }

        private void OnDestroy() =>
            _button.onClick.RemoveListener(ChangeJump);

        private void ChangeJump()
        {
            if (!_inventoryService.HasAnyJump)
                return;

            _inventoryService.SelectNextJump();
            UpdateView();
        }

        private void UpdateView()
        {
            JumpTypeId selectedJump = _inventoryService.SelectedJump;
            _jumpimage.enabled = selectedJump != JumpTypeId.None;

            if (selectedJump == JumpTypeId.None)
                return;
            JumpConfig jumpConfig = _staticDataService.GetJumpConfig(selectedJump);
            _jumpimage.sprite = jumpConfig.Sprite;
        }
    }
}