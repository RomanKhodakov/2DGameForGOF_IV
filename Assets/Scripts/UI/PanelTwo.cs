using UnityEngine;
using UnityEngine.UI;

namespace ExampleGame
{
    internal sealed class PanelTwo : BaseUi
    {
        private readonly Text _text;
        private readonly GameObject _playerScorePanel;
        private readonly PlayerScore _playerScore;

        public PanelTwo(GameObject playerScorePanel, PlayerScore playerScore)
        {
            
            _playerScorePanel = playerScorePanel;
            _playerScore = playerScore;
            _text = playerScorePanel.GetComponentInChildren<Text>();
        }
        
        public override void SetActiveUi()
        {
            if (_playerScorePanel.activeInHierarchy) Cancel();
            else _playerScorePanel.SetActive(true);
        }

        public override void ExecuteUi()
        {
            _text.text = _playerScore.GetCurrentScore();
        }

        public override void Cancel()
        {
            _playerScorePanel.SetActive(false);
        }
    }
}