using UnityEngine;
using UnityEngine.UI;

namespace ExampleGame
{
    internal sealed class PanelOne : BaseUi
    {
        private readonly Text _text;
        private readonly GameObject _playerHealthPanel;
        private readonly Health _playerHp;

        public PanelOne(GameObject playerHealthPanel, Health playerHp)
        {
            _playerHp = playerHp;
            _playerHealthPanel = playerHealthPanel;
            _text = playerHealthPanel.GetComponentInChildren<Text>();
        }
        
        public override void SetActiveUi()
        {
            if (_playerHealthPanel.activeInHierarchy) Cancel();
            else _playerHealthPanel.SetActive(true);
        }

        public override void ExecuteUi()
        {
            _text.text = $"HP: {_playerHp.Current}";
        }

        public override void Cancel()
        {
            _playerHealthPanel.SetActive(false);
        }
    }
}