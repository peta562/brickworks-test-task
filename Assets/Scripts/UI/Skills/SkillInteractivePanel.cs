using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Skills {
    public class SkillInteractivePanel : MonoBehaviour {
        [SerializeField] Button LearnButton;
        [SerializeField] Button ForgetButton;
        [SerializeField] Button ForgetAllButton;
        [SerializeField] TMP_Text LearnPriceText;

        Action _onLearnButtonClicked;
        Action _onForgetButtonClicked;
        Action _onForgetAllButtonClicked;

        public void Init(Action onLearnButtonClicked, Action onForgetButtonClicked, Action onForgetAllButtonClicked) {
            _onLearnButtonClicked = onLearnButtonClicked;
            _onForgetButtonClicked = onForgetButtonClicked;
            _onForgetAllButtonClicked = onForgetAllButtonClicked;

            LearnButton.onClick.AddListener(OnLearnButtonClick);
            ForgetButton.onClick.AddListener(OnForgetButtonClick);
            ForgetAllButton.onClick.AddListener(OnForgetAllButtonClick);
        }

        public void DeInit() {
            _onLearnButtonClicked = null;
            _onForgetButtonClicked = null;
            _onForgetAllButtonClicked = null;

            LearnButton.onClick.RemoveListener(OnLearnButtonClick);
            ForgetButton.onClick.RemoveListener(OnForgetButtonClick);
            ForgetAllButton.onClick.RemoveListener(OnForgetAllButtonClick);
        }

        public void Setup(bool canLearn, bool canForget, int learnPrice) {
            LearnButton.interactable = canLearn;
            ForgetButton.interactable = canForget;

            LearnPriceText.text = $"{learnPrice} points";
        }

        void OnLearnButtonClick() {
            _onLearnButtonClicked?.Invoke();
        }

        void OnForgetButtonClick() {
            _onForgetButtonClicked?.Invoke();
        }

        void OnForgetAllButtonClick() {
            _onForgetAllButtonClicked?.Invoke();
        }
    }
}