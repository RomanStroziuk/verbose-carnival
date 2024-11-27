using System;
using UnityEngine;
using UnityEngine.UI;
namespace Code.Runtime.Gameplay.View.UI
{
    public class PlayerHatChanger : MonoBehaviour
    {
        [SerializeField] 
        private Button _button;

        private void Awake() =>
            _button.onClick.AddListener(ChangeHat);

        private void OnDestroy() =>
            _button.onClick.RemoveListener(ChangeHat);

        private void ChangeHat()
        {
            Debug.Log("Change Hat");
        }
    }
}