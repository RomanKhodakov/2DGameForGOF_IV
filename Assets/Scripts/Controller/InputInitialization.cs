using UnityEngine;

namespace ExampleGame
{
    internal sealed class InputInitialization : IInitialization
    {
        private readonly IUserInputProxy<float> _pcInputHorizontal;
        private readonly IUserInputProxy<float> _pcInputVertical;
        private readonly IUserInputProxy<bool> _pcInputAddAcceleration;
        private readonly IUserInputProxy<bool> _pcInputRemoveAcceleration;
        private readonly IUserInputProxy<bool> _inputFire1;
        private readonly IUserInputProxy<bool> _inputFire2;
        private readonly IUserInputProxy<Vector3> _inputMousePosition;
        private readonly IUserInputProxy<bool> _inputCancel;
        private readonly IUserInputProxy<bool> _inputShowFirstPanel;
        private readonly IUserInputProxy<bool> _inputShowSecondPanel;

        public InputInitialization()
        {
            _pcInputHorizontal = new PCInputHorizontal();
            _pcInputVertical = new PCInputVertical();
            _pcInputAddAcceleration = new PCInputAddAcceleration();
            _pcInputRemoveAcceleration = new PCInputRemoveAcceleration();
            _inputMousePosition = new PCInputMousePosition();
            _inputFire1 = new PCInputFire1();
            _inputFire2 = new PCInputFire2();
            _inputCancel = new PCInputCancel();
            _inputShowFirstPanel = new PCInputShowFirstPanel();
            _inputShowSecondPanel = new PCInputShowSecondPanel();
        }

        public void Initialization()
        {
        }

        public (IUserInputProxy<float> inputHorizontal, IUserInputProxy<float> inputVertical,
            IUserInputProxy<bool> InputAddAceleration, IUserInputProxy<bool> InputRemoveAceleration) GetMoveInput()
        {
            (IUserInputProxy<float> inputHorizontal, IUserInputProxy<float> inputVertical,
                IUserInputProxy<bool> InputAddAceleration, IUserInputProxy<bool> InputRemoveAceleration) result =
                    (_pcInputHorizontal, _pcInputVertical, _pcInputAddAcceleration, _pcInputRemoveAcceleration);
            return result;
        }

        public (IUserInputProxy<Vector3> inputMousePosition, IUserInputProxy<bool> inputFire1, IUserInputProxy<bool>
            inputFire2) GetMouseInput()
        {
            (IUserInputProxy<Vector3> inputMousePosition, IUserInputProxy<bool> inputFire1, IUserInputProxy<bool>
                inputFire2) result = (_inputMousePosition, _inputFire1, _inputFire2);
            return result;
        }

        public (IUserInputProxy<bool> inputCancel, IUserInputProxy<bool> inputShowFirstPanel, 
            IUserInputProxy<bool> inputShowSecondPanel) GetUiInput()
        {
            (IUserInputProxy<bool> inputCancel, IUserInputProxy<bool> inputShowFirstPanel, 
                IUserInputProxy<bool>inputShowSecondPanel) result = (_inputCancel, _inputShowFirstPanel, _inputShowSecondPanel);
            return result;
        }
    }
}