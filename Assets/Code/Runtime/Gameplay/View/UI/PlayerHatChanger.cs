using System;
using Code.Runtime.Data;
using Code.Runtime.Infrastructure.Services.PlayerInventory;
using Code.Runtime.Infrastructure.Services.StaticData;
using Code.Runtime.StaticData;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Runtime.Gameplay.View.UI
{
    public class PlayerHatChanger : MonoBehaviour
    {
        [SerializeField] 
        private Button _button;

        [SerializeField] 
        private Image _hatimage;
        
        private IPlayerInventoryService _inventoryService;
        private IStaticDataService _staticDataService;

        [Inject]
        private void Construct(IPlayerInventoryService inventoryService, IStaticDataService staticDataService )
        {
            _staticDataService = staticDataService;
            _inventoryService = inventoryService;
        }

        private void Awake() =>
            _button.onClick.AddListener(ChangeHat);

        private void Start()
        {
            UpdateView();
        }

        private void OnDestroy() =>
            _button.onClick.RemoveListener(ChangeHat);

        private void ChangeHat()
        {
            if(!_inventoryService.HasEnyHat)
                return;
            
        }

        private void UpdateView()
        {
            HatTypeId selectedHat = _inventoryService.SelectedHat;
            _hatimage.enabled = selectedHat != HatTypeId.None;
            
            if(selectedHat == HatTypeId.None)
                return;
            _staticDataService.GetHatsConfigs(selectedHat)
            


        }
    }
}