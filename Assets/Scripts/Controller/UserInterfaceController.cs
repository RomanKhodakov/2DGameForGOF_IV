using System.Collections.Generic;

namespace ExampleGame
{
    internal sealed class UserInterfaceController : IInitialization, IExecute, ICleanup
    {
        private readonly List<BaseUi> _uiPanels;
        private readonly Stack<StateUI> _stateUi = new Stack<StateUI>();
        private BaseUi _currentWindow;
        private readonly IUserInputProxy<bool> _cancelInputProxy;
        private readonly IUserInputProxy<bool> _firstPanelInputProxy;
        private readonly IUserInputProxy<bool> _secondPanelInputProxy;
        private bool _isCancel;
        private bool _isFirstPanel;
        private bool _isSecondPanel;

        public UserInterfaceController((IUserInputProxy<bool> inputCancel, IUserInputProxy<bool> inputShowFirstPanel, 
            IUserInputProxy<bool> inputShowSecondPanel) input, List<BaseUi> uiPanels)
        {
            _uiPanels = uiPanels;
            _cancelInputProxy = input.inputCancel;
            _firstPanelInputProxy = input.inputShowFirstPanel;
            _secondPanelInputProxy = input.inputShowSecondPanel;
            _firstPanelInputProxy.AxisOnChange += FirstPanelOnAxisOnChange;
            _secondPanelInputProxy.AxisOnChange += SecondPanelOnAxisOnChange;
            _cancelInputProxy.AxisOnChange += CancelOnAxisOnChange;
        }

        public void Initialization()
        {
            foreach (var panel in _uiPanels)
            {
                panel.Cancel();
            }
        }

        private void FirstPanelOnAxisOnChange(bool value)
        {
            _isFirstPanel = value;
        }
        
        private void SecondPanelOnAxisOnChange(bool value)
        {
            _isSecondPanel = value;
        }
        
        private void CancelOnAxisOnChange(bool value)
        {
            _isCancel = value;
        }

        private void SelectAndSetActive(StateUI stateUI, bool isSave = true)
        {
            switch (stateUI)
            {
                case StateUI.PanelOne:
                    _currentWindow = _uiPanels[0];
                    break;

                case StateUI.PanelTwo:
                    _currentWindow = _uiPanels[1];
                    break;

                default:
                    break;
            }

            _currentWindow?.SetActiveUi();
            if (isSave)
            {
                _stateUi.Push(stateUI);
            }
        }

        public void Execute(float deltaTime)
        {
            foreach (var panel in _uiPanels)
            {
                panel.ExecuteUi();
            }
            if (_isFirstPanel)
            {
                SelectAndSetActive(StateUI.PanelOne);
            }

            if (_isSecondPanel)
            {
                SelectAndSetActive(StateUI.PanelTwo);
            }

            if (_isCancel)
            {
                if (_stateUi.Count > 0)
                {
                    SelectAndSetActive(_stateUi.Pop(), false);
                }
            }
        }

        public void Cleanup()
        {
            _cancelInputProxy.AxisOnChange -= CancelOnAxisOnChange;
            _firstPanelInputProxy.AxisOnChange -= FirstPanelOnAxisOnChange;
            _secondPanelInputProxy.AxisOnChange -= SecondPanelOnAxisOnChange;
        }
    }
}