using UnityEngine;

namespace ExampleGame
{
    public sealed class InputController : IExecute
    {
        private readonly IUserInputProxy<float> _horizontal;
        private readonly IUserInputProxy<float> _vertical;
        private readonly IUserInputProxy<bool> _mouseFire1;
        private readonly IUserInputProxy<bool> _mouseFire2;
        private readonly IUserInputProxy<bool> _addAcceleration;
        private readonly IUserInputProxy<bool> _removeAcceleration;
        private readonly IUserInputProxy<Vector3> _mousePosition;
        private readonly IUserInputProxy<bool> _inputCancel;
        private readonly IUserInputProxy<bool> _inputShowFirstPanel;
        private readonly IUserInputProxy<bool> _inputShowSecondPanel;

        public InputController((IUserInputProxy<float> inputHorizontal, IUserInputProxy<float> inputVertical,
                IUserInputProxy<bool> pcAddAceleration, IUserInputProxy<bool> pcRemoveAceleration) input,
            (IUserInputProxy<Vector3> mousePosition, IUserInputProxy<bool> mouseFire1, IUserInputProxy<bool> mouseFire2)
                mouseInput, (IUserInputProxy<bool> inputCancel, IUserInputProxy<bool> inputShowFirstPanel, 
                IUserInputProxy<bool> inputShowSecondPanel) uiInput)
        {
            _horizontal = input.inputHorizontal;
            _vertical = input.inputVertical;
            _addAcceleration = input.pcAddAceleration;
            _removeAcceleration = input.pcRemoveAceleration;
            _mousePosition = mouseInput.mousePosition;
            _mouseFire1 = mouseInput.mouseFire1;
            _mouseFire2 = mouseInput.mouseFire2;
            _inputCancel = uiInput.inputCancel;
            _inputShowFirstPanel = uiInput.inputShowFirstPanel;
            _inputShowSecondPanel = uiInput.inputShowSecondPanel;
        }

        public void Execute(float deltaTime)
        {
            _horizontal.GetAxis();
            _vertical.GetAxis();
            _addAcceleration.GetAxis();
            _removeAcceleration.GetAxis();
            _mousePosition.GetAxis();
            _mouseFire1.GetAxis();
            _mouseFire2.GetAxis();
            _inputCancel.GetAxis();
            _inputShowFirstPanel.GetAxis();
            _inputShowSecondPanel.GetAxis();
        }
    }
}