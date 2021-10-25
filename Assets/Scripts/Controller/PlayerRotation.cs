using UnityEngine;

namespace ExampleGame
{
    public sealed class PlayerRotation : IExecute, ICleanup
    {
        private readonly Transform _unit;
        private readonly Camera _camera;
        private Vector3 _mousePosition;
        private readonly IUserInputProxy<Vector3> _mousePositionInput;

        public PlayerRotation(
            (IUserInputProxy<Vector3> mousePosition, IUserInputProxy<bool> mouseFire1, IUserInputProxy<bool> mouseFire2)
                mouseInput, Transform unit, Camera camera)
        {
            _mousePositionInput = mouseInput.mousePosition;
            _unit = unit;
            _camera = camera;
            _mousePositionInput.AxisOnChange += MousePositionOnAxisOnChange;
        }

        private void MousePositionOnAxisOnChange(Vector3 value)
        {
            _mousePosition = value;
        }

        public void Execute(float deltaTime)
        {
            var direction = _mousePosition - _camera.WorldToScreenPoint(_unit.position);
            var angle = (Mathf.Atan2(direction.y, direction.x) - Mathf.PI / 2) * Mathf.Rad2Deg;
            _unit.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        public void Cleanup()
        {
            _mousePositionInput.AxisOnChange -= MousePositionOnAxisOnChange;
        }
    }
}