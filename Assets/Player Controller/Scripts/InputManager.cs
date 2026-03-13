namespace EasyPeasyFirstPersonController
{
    using UnityEngine;

    public class InputManager : MonoBehaviour, IInputManager
    {
        private PlayerInputs _playerInputs;

        private void Awake()
        {
            _playerInputs = new PlayerInputs();
        }

        private void OnEnable()
        {
            _playerInputs.Player.Enable();
        }

        private void OnDisable()
        {
            _playerInputs.Player.Disable();
        }

        public Vector2 moveInput => _playerInputs.Player.Move.ReadValue<Vector2>();
        public Vector2 lookInput => _playerInputs.Player.Look.ReadValue<Vector2>();
        public bool jump => _playerInputs.Player.Jump.IsPressed();
        public bool sprint => _playerInputs.Player.Sprint.IsPressed();
        public bool crouch => _playerInputs.Player.Crouch.IsPressed();
        public bool slide => _playerInputs.Player.Slide.IsPressed();
    }
}
