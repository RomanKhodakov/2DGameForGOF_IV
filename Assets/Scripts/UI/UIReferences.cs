using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExampleGame
{
    internal sealed class UIReferences
    {
        private Canvas _canvas;
        private GameObject _playerHealthPanel;
        private GameObject _playerScorePanel;
        
        private Canvas Canvas
        {
            get
            {
                if (_canvas == null)
                {
                    _canvas = Object.FindObjectOfType<Canvas>();
                }
                return _canvas;
            }
        }
        public GameObject PlayerHealthPanel
        {
            get
            {
                if (_playerHealthPanel == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/PlayerHeathPanel");
                    _playerHealthPanel = Object.Instantiate(gameObject, Canvas.transform);
                }

                return _playerHealthPanel;
            }
        }
        public GameObject PlayerScorePanel
        {
            get
            {
                if (_playerScorePanel == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/PlayerScorePanel");
                    _playerScorePanel = Object.Instantiate(gameObject, Canvas.transform);
                }

                return _playerScorePanel;
            }
        }
    }
}
