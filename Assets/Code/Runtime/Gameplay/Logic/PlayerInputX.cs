using UnityEngine;

namespace Code.Runtime.Gameplay.Logic
{
    public class PlayerInputX : MonoBehaviour
    {
        [SerializeField] private MoverX _mover;
        private const string AxisHorizontal = "Horizontal";

        private void Update()
        {
            float input = Input.GetAxis(AxisHorizontal);
            _mover.Move(input);
        }
    }
}