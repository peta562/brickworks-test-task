using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Points {
    public class PointsView : MonoBehaviour {
        [SerializeField] Button EarnButton;
        [SerializeField] TMP_Text PointsText;
        
        Action _onEarnButtonClicked;

        public void Init(Action onEarnButtonClicked) {
            _onEarnButtonClicked = onEarnButtonClicked;
            EarnButton.onClick.AddListener(OnEarnButtonClick);
        }

        public void DeInit() {
            _onEarnButtonClicked = null;
            EarnButton.onClick.RemoveListener(OnEarnButtonClick);
        }

        public void UpdatePointsText(int points) {
            PointsText.text = $"You have {points} points";
        }

        void OnEarnButtonClick() {
            _onEarnButtonClicked?.Invoke();
        }
    }
}