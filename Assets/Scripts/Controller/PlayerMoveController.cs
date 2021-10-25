using UnityEngine;

namespace ExampleGame
{
    internal sealed class PlayerMoveController : IMovePlayer
    {
        private readonly PlayerState _playerState;
        private readonly IUnit _unitData;
        private float _horizontal;
        private float _vertical;
        private float _playerSpeed;
        private bool _addAcceleration;
        private bool _removeAcceleration;
        private readonly IUserInputProxy <float>  _horizontalInputProxy;
        private readonly IUserInputProxy <float>  _verticalInputProxy;
        private readonly IUserInputProxy <bool> _addAccelerationInputProxy;
        private readonly IUserInputProxy <bool> _removeAccelerationInputProxy;

        public PlayerMoveController((IUserInputProxy <float> inputHorizontal, IUserInputProxy <float> inputVertical, 
                IUserInputProxy <bool> inputAddAcceleration, IUserInputProxy <bool> inputRemoveAcceleration) input, 
                PlayerInitialization playerInitialization, IUnit unitData)
        {
            _playerState = playerInitialization.GetPlayerState();
            _unitData = unitData;
            _playerSpeed = _unitData.Speed;
            _horizontalInputProxy = input.inputHorizontal;
            _verticalInputProxy = input.inputVertical;
            _addAccelerationInputProxy = input.inputAddAcceleration;
            _removeAccelerationInputProxy = input.inputRemoveAcceleration;
            _horizontalInputProxy.AxisOnChange += HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange += VerticalOnAxisOnChange;
            _addAccelerationInputProxy.AxisOnChange += AddAccelerationOnAxisOnChange;
            _removeAccelerationInputProxy.AxisOnChange += RemoveAccelerationOnAxisOnChange;
        }

        private void VerticalOnAxisOnChange(float value)
        {
            _vertical = value;
        }

        private void HorizontalOnAxisOnChange(float value)
        {
            _horizontal = value;
        }

        private void AddAccelerationOnAxisOnChange(bool value)
        {
            _addAcceleration = value;
        }
        private void RemoveAccelerationOnAxisOnChange(bool value)
        {
            _removeAcceleration = value;
        }

        public void Move(float deltaTime)
        {
            if (_addAcceleration)
            {
                _playerSpeed += _unitData.AccelerationSpeed;
            }

            if (_removeAcceleration)
            {
                _playerSpeed -= _unitData.AccelerationSpeed;
            }
            _playerState.Request(_horizontal, _vertical, _playerSpeed, deltaTime);
        }

        public void Cleanup()
        {
            _horizontalInputProxy.AxisOnChange -= HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange -= VerticalOnAxisOnChange;
            _addAccelerationInputProxy.AxisOnChange -= AddAccelerationOnAxisOnChange;
            _removeAccelerationInputProxy.AxisOnChange -= RemoveAccelerationOnAxisOnChange;
        }
    }
}